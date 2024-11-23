namespace CareNestSolution.Chat.Interfaces.REST.Resources;

public record CreateChatResource(
    int ParentId,
    int CaregiverId
);

public record SendMessageResource(
    int SenderId,
    string Content
);