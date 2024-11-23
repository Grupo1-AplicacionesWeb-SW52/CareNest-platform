namespace CareNestSolution.Chat.Domain.Model.Entities
{
    public class ChatEntity
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public int CaregiverId { get; set; }
        public List<MessageEntity> Messages { get; set; }
    }
}