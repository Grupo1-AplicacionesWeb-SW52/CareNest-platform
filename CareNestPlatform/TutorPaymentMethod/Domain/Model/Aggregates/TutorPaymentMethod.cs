namespace CarNest.TutorPaymentMethod.Domain.Model.Aggregates;

public class TutorPaymentMethod
{
    public int Id { get; set; }
    public int  TutorId { get; set; }
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
        int tutorId
    )
    {
        CardNumber = cardNumber;
        ExpirationDate = DateTime.Parse(expirationDate);
        Cvv = cvv;
        CardHolder = cardHolder;
        TutorId = tutorId;
    }
}