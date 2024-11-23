using CareNestSolution.Chat.Domain.Model.Commands;

namespace CareNestSolution.Chat.Domain.Model.Aggregate
{
    public class MessageAggregate
    {
        public int Id { get; private set; }
        public int ChatId { get; private set; }
        public int SenderId { get; private set; }
        public string Content { get; private set; }
        public DateTime SentAt { get; private set; }

        // Constructor que recibe un comando
        public MessageAggregate(SendMessageCommand command)
        {
            ChatId = command.ChatId;
            SenderId = command.SenderId;
            Content = command.Content;
            SentAt = DateTime.UtcNow; // Establece la fecha y hora actual
        }

        // Método que podría tener lógica de negocio, por ejemplo, validar el contenido
        public void ValidateMessage()
        {
            if (string.IsNullOrEmpty(Content))
                throw new ArgumentException("Message content cannot be empty.");
        }

        // Método para modificar el contenido del mensaje (en caso de que se requiera)
        public void EditMessage(string newContent)
        {
            if (string.IsNullOrEmpty(newContent))
                throw new ArgumentException("New content cannot be empty.");
            
            Content = newContent;
        }
    }
}