namespace WebApplication3.CaregiverPaymentMethod.Domain.Model.Aggregates;

public class CaregiverPaymentMethod
{
    public int Id { get; set; }
    public int CaregiverId { get; set; }
    public string CardNumber { get; set; }
    public DateTime ExpirationDate { get; set; }
    public string Cvv { get; set; }
    public string CardHolder { get; set; }
    
    private CaregiverPaymentMethod(){}

    public CaregiverPaymentMethod(
        string cardNumber,
        string expirationDate,
        string cvv,
        string cardHolder,
        int caregiverId 
    )
    {
        CardNumber = cardNumber;
        ExpirationDate = DateTime.Parse(expirationDate);
        Cvv = cvv;
        CardHolder = cardHolder;
        CaregiverId = caregiverId;
    }
}