using System;

namespace FlightServiceConsumeApplication.Models
{
    public class FlightSegmentDto
    {
        public string Origin { get; set; }
        public string Destination { get; set; }
        public DateTime OnwardDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
