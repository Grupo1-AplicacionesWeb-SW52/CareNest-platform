namespace CarNest.Reservations.Domain.Model.Aggregates{
    public class Reservation
    {
        public int Id { get; set; }
        public int CaregiverId { get; set; }
        public int TutorId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }
        public decimal TotalFare { get; set; }

        private Reservation() { }

        public Reservation(int caregiverId, int tutorId, DateTime startDate, DateTime endDate, string status, decimal totalFare)
        {
            CaregiverId = caregiverId;
            TutorId = tutorId;
            StartDate = startDate;
            EndDate = endDate;
            Status = status;
            TotalFare = totalFare;
        }
    }
}