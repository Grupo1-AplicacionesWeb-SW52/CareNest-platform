using CareNestSolution.Chat.Domain.Model.Entities;
using CareNestSolution.Chat.Domain.Model.Aggregate;

namespace CareNestSolution.Chat.Interfaces.REST.Transform
{
    public static class ChatAggregateToEntityAssembler
    {
        // Este método convierte un ChatAggregate en un ChatEntity
        public static ChatEntity ToEntityFromAggregate(ChatAggregate aggregate)
        {
            if (aggregate == null)
                throw new ArgumentNullException(nameof(aggregate));

            return new ChatEntity
            {
                Id = aggregate.Id,
                ParentId = aggregate.ParentId,
                CaregiverId = aggregate.CaregiverId,
                Messages = aggregate.Messages.Select(m => new MessageEntity
                {
                    SenderId = m.SenderId,
                    Content = m.Content,
                    SentAt = m.SentAt
                }).ToList() // Convierte la lista de MessageAggregate a MessageEntity
            };
        }
    }
}
