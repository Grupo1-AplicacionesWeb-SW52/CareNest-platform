using CareNestSolution.Chat.Domain.Model.Aggregate;
using CareNestSolution.Chat.Domain.Model.Queries;
using CareNestSolution.Chat.Domain.Repositories;
using CareNestSolution.Chat.Domain.Services;

namespace CareNestSolution.Chat.Application.Internal.QueryServices;

public class ChatQueryService : IChatQueryService
{
    private readonly IChatRepository _chatRepository; // Use the correct IChatRepository

    public ChatQueryService(IChatRepository chatRepository)
    {
        _chatRepository = chatRepository;
    }

    public async Task<IEnumerable<ChatAggregate>> Handle(GetAllChatsQuery query)
    {
        return await _chatRepository.ListAsync(); // Ensure proper listing of chats
    }

    public async Task<ChatAggregate?> Handle(GetChatByIdQuery query)
    {
        return await _chatRepository.FindByIdAsync(query.Id); // Handle by ID query correctly
    }
}