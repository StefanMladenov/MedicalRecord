using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eKarton.Models.SQL
{
    public class Osoba
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

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

        public string EMail { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

    }
    public class Lekar : Osoba
    {
        public string Specijalizacija { get; set; }
        public Ustanova Ustanova { get; set; }
        public int BrFaksimila { get; set; }
    }

    public class Pacijent : Osoba
    {
        public string ImeOca { get; set; }
        public string ImeMajke { get; set; }

        // 1- za musko , 2 - za zensko
        public int Pol { get; set; }
        public int LBO { get; set; }

        // 1 - drzavno, 2 - privatno
        public int VidOsiguranja { get; set; }
    }
}
