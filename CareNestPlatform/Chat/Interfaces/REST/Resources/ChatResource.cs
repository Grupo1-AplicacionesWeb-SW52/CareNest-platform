namespace CareNestSolution.Chat.Interfaces.REST.Resources;

public record ChatResource(
    int Id,
    int ParentId,
    int CaregiverId,
    List<MessageResource> Messages
);

public record MessageResource(
    int SenderId,
    string Content,
    DateTime SentAt
);