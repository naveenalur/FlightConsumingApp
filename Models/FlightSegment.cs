using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightServiceConsumeApplication.Models
{
    public class FlightSegment
    {
        public string Origin { get; set; }
        public string Destination { get; set; }
        public DateTime OnwardDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public string Airline { get; set; }
        public string FlightNumber { get; set; }
        public string FlightType { get; set; }
    
    }
}
