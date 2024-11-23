using CareNestSolution.Chat.Interfaces.REST.Resources;
using CareNestSolution.Chat.Domain.Model.Commands;
namespace CareNestSolution.Chat.Interfaces.REST.Transform;

public static class CreateChatCommandFromEntityAssembler
{
    public static CreateChatCommand ToCommandFromResource(CreateChatResource resource)
    {
        return new CreateChatCommand(
            0, // Assuming ID is auto-generated
            resource.ParentId,
            resource.CaregiverId
        );
    }

    public static SendMessageCommand ToSendMessageCommandFromResource(SendMessageResource resource, int chatId)
    {
        return new SendMessageCommand(
            chatId,
            resource.SenderId,
            resource.Content
        );
    }
}