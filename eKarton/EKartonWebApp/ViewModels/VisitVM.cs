using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EKartonWebApp.ViewModels
{
    public class VisitVM
    {
        public int HealthInsuranceNumber { get; set; }

        [StringLength(13, MinimumLength = 13)]
        public string PatientUCIN { get; set; }
        public string Therapy { get; set; }

        [StringLength(13, MinimumLength = 13)]
        public string DoctorUCIN { get; set; }
        public string WorkingDiagnosis { get; set; }
        public string CurrentFinding { get; set; }
        public string[] FilePaths { get; set; }
        public List<IFormFile> MyImage { set; get; }
    }
}
