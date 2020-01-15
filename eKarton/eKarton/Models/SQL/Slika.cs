using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eKarton.Models.SQL
{
    public class Slika
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
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
        public Ustanova Ustanova { get; set; }
        public Lekar Lekar { get; set; }
    }

    public class Snimak : Slika
    {
        public string DeoTela { get; set; }
    }

    public class Rentgen : Snimak
    {

    }

    public class Ultrazvuk:Snimak
    {

    }

    public class Skener:Snimak
    {

    }
    public class NuklearnaMagnetnaRezonanca:Snimak
    {

    }
    public class Ostalo : Snimak
    {

    }

}
