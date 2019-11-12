using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eKarton.Models.SQL
{
    public class Vakcina
    {
        public int VakcinaID { get; set; }
        public string ImeVakcine { get; set; }
        
        //if trajanje==null then neograniceno else dani
        public int Trajanje { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Datum vakcinacije")]
        public DateTime DatumVakcinacije { get; set; }
    }
}
