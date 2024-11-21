namespace WebApplication3.Caregivers.Domain.Model.ValueObjects;

public class CaregiverAddress
{
    public string AddressLine { get; private set; }
    public string District { get; private set; }

    public CaregiverAddress(string addressLine, string district)
    {
        AddressLine = addressLine;
        District = district;
    }
}