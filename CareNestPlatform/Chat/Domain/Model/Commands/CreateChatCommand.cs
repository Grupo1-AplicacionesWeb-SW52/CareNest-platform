namespace CareNestSolution.Chat.Domain.Model.Commands;

public record CreateChatCommand(
    int Id,
    int ParentId,
    int CaregiverId
);