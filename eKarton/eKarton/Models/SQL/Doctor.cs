namespace eKarton.Models.SQL
{
    public class Doctor : Person
    {
        public string Specialization { get; set; }
        public Institute Institute { get; set; }
    }
}
