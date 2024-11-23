namespace CareNestSolution.Chat.Domain.Model.Entities
{
    public class MessageEntity
    {
        public int Id { get; set; }
        public int ChatId { get; set; }
        public int SenderId { get; set; }
        public string Content { get; set; }
        public DateTime SentAt { get; set; }
    }
}