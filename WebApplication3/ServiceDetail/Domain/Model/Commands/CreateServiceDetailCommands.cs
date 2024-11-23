using System.Collections.Generic;
using WebApplication3.ServiceDetail.Domain.Model.ValueObjects;

namespace WebApplication3.ServiceDetail.Domain.Model.Commands
{
    public class CreateServiceDetailCommand
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public List<string> Places { get; set; }
        public List<Schedule> Schedules { get; set; }
        public string CaregiverName { get; set; }
        public string CaregiverAddress { get; set; }
        public string CaregiverDistrict { get; set; }
    }
}
