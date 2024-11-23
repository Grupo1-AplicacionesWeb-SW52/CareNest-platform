namespace CarNest.Reservations.Domain.Model.Commands
{
    public class CreateReservationCommand
    {
        public int TutorId { get; set; }
        public int CaregiverId { get; set; }
        public int ServiceId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public decimal TotalFare { get; set; }
    }



}