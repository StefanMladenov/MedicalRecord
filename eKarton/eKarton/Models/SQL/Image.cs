
namespace eKarton.Models.SQL
{
    public abstract class Image : AbstractEntity
    {
        public string ImagePath { get; set; }
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
        public AnalysisType SnapshotType { get; set; }
    }

    public enum SnapshotType
    {
        XRAY = 1,
        ULTRASOUND = 2,
        SCANNER = 3,
        NUCLEAR_MAGNETIC_RESONANCE = 4,
        OTHER = 5
    }

    public enum AnalysisType
    {
        LABORATORY = 1,
        SPIROMETRY = 2,
        ALLERGOLOGICAL_TESTS = 3,
        OTHER = 4
    }
}
