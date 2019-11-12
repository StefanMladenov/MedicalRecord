using System;
using System.ComponentModel.DataAnnotations;

namespace eKarton.Models.SQL
{
    public class Osoba
    {
        public int OsobaID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Ime")]
        public string Ime { get; set; }
        
        [Required]
        [StringLength(50)]
        [Display(Name = "Prezime")]
        public string Prezime { get; set; }
        public string JMBG { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Datum rodjenja")]
        public DateTime DatumRodjenja { get; set; }

    }
    public class Lekar : Osoba
    {
        public string Specijalizacija { get; set; }
        public int GodineRadnogStaza { get; set; }
        public string Ustanova { get; set; }
        public string Ordinacija { get; set; }
        public int BrFaksimila { get; set; }
    }

    public class Pacijent : Osoba
    {
        public string ImeOca { get; set; }
        public string ImeMajke { get; set; }
        public string KrvnaGrupa { get; set; }
        public int Tezina { get; set; }
        public int Visina { get; set; }
        public int LBO { get; set; }
    }
}
