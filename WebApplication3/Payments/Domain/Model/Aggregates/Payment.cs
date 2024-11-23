namespace WebApplication3.Payments.Domain.Model.Aggregates;

public class Payment
{
    public int Id { get; set; }
    public int? CaregiverId { get; set; }
    public int? TutorId { get; set; }
    public string CardNumber { get; set; }
    public DateTime CreatedAt { get; set; } // start date
    public string Type { get; set; } // Type: "pay" o "deposit"
    public decimal Amount { get; set; }

    private Payment() { }

    public Payment(
        string cardNumber,
        DateTime createdAt,
        string type,
        decimal amount,
        int? caregiverId = null,
        int? tutorId = null
    )
    {
        if (caregiverId == null && tutorId == null)
            throw new ArgumentException("You need to specify a caregiver or tutor.");
        CardNumber = cardNumber;
        CreatedAt = createdAt;
        Type = type;
        Amount = amount;
        CaregiverId = caregiverId;
        TutorId = tutorId;
    }
}