using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eKarton.Models.SQL
{
    public class Vakcina
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string ImeVakcine { get; set; }
        
        //if trajanje==null then neograniceno else dani
        public int Trajanje { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Datum vakcinacije")]
        public DateTime DatumVakcinacije { get; set; }
    }
}
