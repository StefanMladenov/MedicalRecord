using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EKartonWebApp.ViewModels
{
    public class HomeVM
    {
        public Tip Tip { get; set; }
        public string JBMG { get; set; }

        public string PictureLocation = "C:\\Users\\ktg\\Desktop\\doctor.png";
    }

    public enum Tip
    {
        Lekar,
        Pacijent
    }
}
