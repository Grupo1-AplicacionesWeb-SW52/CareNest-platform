using CareNestSolution.Chat.Interfaces.REST.Resources;
using CareNestSolution.Chat.Domain.Model.Entities;

namespace CareNestSolution.Chat.Interfaces.REST.Transform;

public static class ChatResourceFromEntityAssembler
{
    public static ChatResource ToResourceFromEntity(ChatEntity entity)
    {
        var messageResources = entity.Messages.Select(m => new MessageResource(
            m.SenderId,
            m.Content,
            m.SentAt
        )).ToList();

        return new ChatResource(
            entity.Id,
            entity.ParentId,
            entity.CaregiverId,
            messageResources
        );
    }
}