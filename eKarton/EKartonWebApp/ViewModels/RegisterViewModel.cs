using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EKartonWebApp.ViewModels
{
    public class RegisterViewModel
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string JMBG { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string EMail { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Tip { get; set; }
        public string LBO { get; set; }
        public string BrojFaksimila { get; set; }
    }
}
