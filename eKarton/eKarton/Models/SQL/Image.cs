
namespace eKarton.Models.SQL
{
    public abstract class Image : AbstractEntity
    {
        public string ImagePath { get; set; }

        public ImageType ImageType { get; set; }
    }

    public class Instruction : Image
    {
        public string SpecializationTo { get; set; }
    }

    public class Snapshot : Image
    {
        public string BodyPart { get; set; }
        public SnapshotType SnapshotType { get; set; }
    }

    public class Analysis : Image
    {
        public AnalysisType AnalysisType { get; set; }
    }
    public enum ImageType
    {
        SNAPSHOT = 1,
        INSTRUCTION = 2,
        ANALYSIS = 3
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
