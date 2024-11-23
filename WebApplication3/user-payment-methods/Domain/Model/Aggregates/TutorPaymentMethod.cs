namespace WebApplication3.user_payment_methods.Domain.Model.Aggregates;

public class TutorPaymentMethod
{
    public int Id { get; set; }
    public int ? CaregiverId { get; set; }
    public int ? TutorId { get; set; }
    public string CardNumber { get; set; }
    public DateTime ExpirationDate { get; set; }
    public string Cvv { get; set; }
    public string CardHolder { get; set; }
    
    private TutorPaymentMethod(){}

    public TutorPaymentMethod(
        string cardNumber,
        string expirationDate,
        string cvv,
        string cardHolder,
        int? caregiverId = null,
        int? tutorId = null
    )
    {
        if (caregiverId == null && tutorId == null)
            throw new ArgumentException("You need to specify a caregiver or tutor.");
        CardNumber = cardNumber;
        ExpirationDate = DateTime.Parse(expirationDate);
        Cvv = cvv;
        CardHolder = cardHolder;
        CaregiverId = caregiverId;
        TutorId = tutorId;
    }
}