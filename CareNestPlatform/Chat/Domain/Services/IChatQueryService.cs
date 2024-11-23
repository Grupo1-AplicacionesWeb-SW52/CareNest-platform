using CareNestSolution.Chat.Domain.Model.Aggregate;
using CareNestSolution.Chat.Domain.Model.Queries;

namespace CareNestSolution.Chat.Domain.Services;

    
    public interface IChatQueryService
    {
        Task<IEnumerable<ChatAggregate>> Handle(GetAllChatsQuery query);
        Task<ChatAggregate?> Handle(GetChatByIdQuery query);
    }
