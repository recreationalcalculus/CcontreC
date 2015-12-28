using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CcontreC.Models
{
    class PatientDataModel
    {
        public enum SexOptions
        {
            Male,
            Female
        };

        public enum ConcussionStatus
        {
            Suspected,
            Confirmed,
            NotSuspected
        };

        public enum Races
        {
            White,
            Black,
            Hispanic,
            Asian,
            Other
        }

        public int Age { get; set; }
        public int HeightInInches { get; set; }
        public int WeightInPounds { get; set; }
        public Races Race { get; set; }
        public SexOptions Sex { get; set; }
        public ConcussionStatus Concussion { get; set; }
    }
}
