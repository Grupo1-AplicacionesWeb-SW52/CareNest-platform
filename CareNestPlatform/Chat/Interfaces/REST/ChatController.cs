using CareNestSolution.Chat.Domain.Model.Queries;
using CareNestSolution.Chat.Domain.Repositories;
using CareNestSolution.Chat.Domain.Services;
using CareNestSolution.Chat.Interfaces.REST.Resources;
using CareNestSolution.Chat.Interfaces.REST.Transform;
using CareNestSolution.Shared.Domain.Respositories;
using Microsoft.AspNetCore.Mvc;

namespace CareNestSolution.Chat.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
public class ChatController : ControllerBase
{
    private readonly IChatQueryService _chatQueryService;
    private readonly IChatCommandService _chatCommandService;
    private readonly IChatRepository _chatRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ChatController(IChatQueryService chatQueryService, IChatCommandService chatCommandService, IChatRepository chatRepository, IUnitOfWork unitOfWork)
    {
        _chatQueryService = chatQueryService;
        _chatCommandService = chatCommandService;
        _chatRepository = chatRepository;
        _unitOfWork = unitOfWork;
    }

    [HttpGet("{chatId:int}")]
    public async Task<IActionResult> GetChatById(int chatId)
    {
        var chat = await _chatQueryService.Handle(new GetChatByIdQuery(chatId));
        if (chat == null)
            return NotFound();

        var chatResource = ChatResourceFromEntityAssembler.ToResourceFromEntity(chat);
        return Ok(chatResource);
    }

    [HttpPost]
    public async Task<IActionResult> CreateChat([FromBody] CreateChatResource resource)
    {
        var createChatCommand = CreateChatCommandFromEntityAssembler.ToCommandFromResource(resource);
        var chat = await _chatCommandService.Handle(createChatCommand);
        if (chat == null)
            return BadRequest();

         var chatEntity = ChatAggregateToEntityAssembler.ToEntityFromAggregate(chat);

        // Guardar en el repositorio
        await _chatRepository.AddAsync(chatEntity);
        await _unitOfWork.CompleteAsync(); // Asegúrate de guardar los cambios en la base de datos

        var chatResource = ChatResourceFromEntityAssembler.ToResourceFromEntity(chatEntity);
        return CreatedAtAction(nameof(GetChatById), new { chatId = chatEntity.Id }, chatResource);
    }

    [HttpPost("{chatId:int}/message")]
    public async Task<IActionResult> SendMessage(int chatId, [FromBody] SendMessageResource resource)
    {
        var sendMessageCommand = CreateChatCommandFromEntityAssembler.ToSendMessageCommandFromResource(resource, chatId);
        var message = await _chatCommandService.Handle(sendMessageCommand);
        if (message == null)
            return BadRequest();

        return Ok(message);
    }
}
