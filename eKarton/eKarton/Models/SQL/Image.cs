
namespace eKarton.Models.SQL
{
    public class Image : AbstractEntity
    {
        public string ImagePath { get; set; }
        public ImageType ImageType { get; set; }
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
    
    public class Analysis : Image
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

    public enum ImageType
    {
        Laboratory,
        Spirometry,
        AllergologicalTests,
        Other
    }
}
