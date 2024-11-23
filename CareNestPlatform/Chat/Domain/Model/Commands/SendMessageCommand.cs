namespace CareNestSolution.Chat.Domain.Model.Commands;

public record SendMessageCommand(
    int ChatId,
    int SenderId,
    string Content
);