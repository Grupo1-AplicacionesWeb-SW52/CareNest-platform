using CarNest.Caregivers.Domain.Model.Aggregates;
using CarNest.Services.Domain.Model.Aggregates;
using CarNest.Tutors.Domain.Model.Aggregates;

namespace CarNest.Reservations.Domain.Model.Aggregates;

public class Reservation
{
   public int Id { get; set; }
    public int TutorId { get; set; }
    public int CaregiverId { get; set; }
    public int ServiceId { get; set; }
    public DateTime CreatedAt { get; set; }
    public ReservationStatus Status { get; set; }
    public Schedule Schedule { get; set; }
    public decimal TotalFare { get; set; }
    
    public Reservation() { }

    // Navigation properties
    public Tutor Tutor { get; private set; } = null!;
    public Caregiver Caregiver { get; private set; } = null!;
    public Service Service { get; private set; } = null!;
    
    public Reservation(int caregiverId, int tutorId, int serviceId, DateTime createdAt, 
                       DateTime startTime, DateTime endTime, decimal totalFare, ReservationStatus status)
    {
        CaregiverId = caregiverId;
        TutorId = tutorId;
        ServiceId = serviceId;
        CreatedAt = createdAt;
        Schedule = new Schedule(startTime, endTime);
        TotalFare = totalFare;
        Status = status;
    }
}


public enum ReservationStatus
{
    Pending,
    Confirmed,
    Completed,
    Canceled
}


public class Schedule
{
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }

   
    public Schedule(DateTime startTime, DateTime endTime)
    {
        StartTime = startTime;
        EndTime = endTime;
    }
    
    public Schedule() { }
}

