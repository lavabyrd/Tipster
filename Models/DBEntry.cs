using System;

namespace Tipster.Models
{

public class Race
    {
        
        public string Id { get; set; }

        public string RaceCourse { get; set; }

        public string DateRan { get; set; }

        public decimal Amount { get; set; }

        public bool Result { get; set; }
    }
}
