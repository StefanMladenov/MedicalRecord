using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eKarton.Models.SQL
{
    public class Image
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string ImagePath { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date of taking picture")]
        public DateTime Date { get; set; }

        public ImageType ImageType { get; set; }
    }

    public enum ImageType
    {
        Laboratory,
        Spirometry,
        AllergologicalTests
    }

    public class Instruction : Image 
    {
        public Institute Institute { get; set; }
        public Doctor DoctorFrom { get; set; }
        public Doctor DoctorTo { get; set; }
    }

    public class Snapshot : Image
    {
        public string BodyPart { get; set; }

        public SnapshotType SnapshotType { get; set; }
    }

    public enum SnapshotType
    {
        XRay,
        Ultrasound,
        Scanner,
        NuclearMagneticResonance,
        Other
    }

    //public class AlergoloskeProbe : Image
    //{

    //}

    //public class Laboratorija : Image
    //{

    //}
    //public class Spirometry : Image
    //{

    //}

    //public class Rentgen : Picture
    //{

    //}

    //public class Ultrazvuk: Picture
    //{

    //}

    //public class Skener: Picture
    //{

    //}
    //public class NuklearnaMagnetnaRezonanca: Picture
    //{

    //}
    //public class Ostalo : Picture
    //{

    //}

}
