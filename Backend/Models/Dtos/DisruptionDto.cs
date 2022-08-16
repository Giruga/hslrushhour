using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HSLRushHour.Backend.Models.Dtos
{
    public class DisruptionDto
    {
        public string header { get; set; } = "";
        public string description { get; set; } = "";
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public string? routeProvider { get; set; } = null;
        public int? routeNumber { get; set; } = null;
    }
}