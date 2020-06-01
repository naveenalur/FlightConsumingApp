using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlightServiceConsumeApplication.Models
{
    public class FlightSegment
    {
        public string Origin { get; set; }
        public string Destination { get; set; }
        [DataType(DataType.Date)]
        public DateTime OnwardDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime ReturnDate { get; set; }
        public string Airline { get; set; }
        public string FlightNumber { get; set; }
        public string FlightType { get; set; }

    }
}
