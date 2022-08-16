using HSLRushHour.Backend.Models.Dtos;

namespace HSLRushHour.Backend.Models
{
    public class Disruption
    {
        public Guid id { get; set; }
        public string header { get; set; } = "";
        public string description { get; set; } = "";
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public BusRoute? route { get; set; } = null;
    }

    public class BusRoute
    {
        public string gtfsId { get; set; } = "";
    }
}