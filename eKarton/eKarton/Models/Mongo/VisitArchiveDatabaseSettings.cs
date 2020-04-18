namespace eKarton.Models
{
    public class VisitArchiveDatabaseSettings : IVisitArchiveDatabaseSettings
    {
        public string VisitsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IVisitArchiveDatabaseSettings
    {
        string VisitsCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
