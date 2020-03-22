using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EKartonWebApp.ViewModels
{
    public class MedicalRecordCreateVM
    {
        public string DoctorUCIN { get; set; }

        public string PatientUCIN { get; set; }

        public string FathersUCIN { get; set; }

        public string PatientName { get; set; }

        public string PatientSurname { get; set; }

    }
}
