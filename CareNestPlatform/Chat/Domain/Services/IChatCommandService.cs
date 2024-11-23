namespace CareNestSolution.Chat.Domain.Services;
using CareNestSolution.Chat.Domain.Model.Aggregate;
using CareNestSolution.Chat.Domain.Model.Commands;


    public interface IChatCommandService
    {
        Task<ChatAggregate?> Handle(CreateChatCommand command);
        Task<MessageAggregate?> Handle(SendMessageCommand command);
    }
