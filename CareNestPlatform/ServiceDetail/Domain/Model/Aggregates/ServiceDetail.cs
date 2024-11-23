using System;
using System.Collections.Generic;

namespace WebApplication3.ServiceDetail.Domain.Model.Aggregates
{
    public class ServiceDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public List<string> Places { get; set; } = new List<string>();
        public List<Schedule> Schedules { get; set; } = new List<Schedule>();
        public string CaregiverName { get; set; }
        public string CaregiverAddress { get; set; }
        public string CaregiverDistrict { get; set; }
    }
}
