using CareNestSolution.Chat.Domain.Model.Commands;

namespace CareNestSolution.Chat.Domain.Model.Aggregate;

public class ChatAggregate
{
    public int Id { get; private set; }   
    public int ParentId { get; private set; }
    public int CaregiverId { get; private set; }
    public List<MessageAggregate> Messages { get; private set; }

    public ChatAggregate(CreateChatCommand command)
    {
        Id = command.Id;   
        ParentId = command.ParentId;
        CaregiverId = command.CaregiverId;
        Messages = new List<MessageAggregate>();  
    }
}