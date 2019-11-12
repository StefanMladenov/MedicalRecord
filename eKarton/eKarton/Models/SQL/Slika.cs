using System;
using System.ComponentModel.DataAnnotations;

namespace eKarton.Models.SQL
{
    public class Slika
    {
        public int SlikaID { get; set; }

        public string ImagePath { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Datum kreiranja slile")]
        public DateTime Datum { get; set; }

        public string TipSlike { get; set; }
    }

    public class AlergoloskeProbe : Slika
    {

    }

    public class Laboratorija : Slika 
    { 

    }
    public class Spirometrija: Slika 
    {

    }
    public class Uput : Slika 
    {

    }

    public class Snimak : Slika
    {
        public string DeoTela { get; set; }
    }

}
