using eKarton.Models.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eKarton.Models
{
    public class Visit
    {
        public int Id { get; set; }
     
        public string Therapy { get; set; }

        public DateTime Date { get; set; }

        public string WorkingDiagnosis { get; set; }

        public string CurrentFinding { get; set; }

        public ICollection<int> ImageIds { get; set; }
    }
}
