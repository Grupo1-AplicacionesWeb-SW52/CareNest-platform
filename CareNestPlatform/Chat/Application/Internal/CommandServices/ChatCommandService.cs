using CareNestSolution.Chat.Domain.Model.Commands;
using CareNestSolution.Chat.Domain.Services;
using CareNestSolution.Shared.Domain.Respositories;
using CareNestSolution.Chat.Domain.Model.Aggregate;

namespace CareNestSolution.Chat.Application.Internal.CommandServices;

public class ChatCommandService : IChatCommandService
{
    private readonly IUnitOfWork _unitOfWork;

    public ChatCommandService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ChatAggregate?> Handle(CreateChatCommand command)
    {
        var chat = new ChatAggregate(command);
        await _unitOfWork.CompleteAsync(); // Ensure transaction is committed
        return chat;
    }

    public async Task<MessageAggregate?> Handle(SendMessageCommand command)
    {
        var message = new MessageAggregate(command); // Now MessageAggregate is defined and can be used
        await _unitOfWork.CompleteAsync(); // Ensure transaction is committed
        return message;
    }
}