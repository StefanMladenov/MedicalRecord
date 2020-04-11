namespace eKarton.Models.SQL
{
    public class Patient : Person
    {
        public string FathersName { get; set; }
        public string MothersName { get; set; }
        public GenderDiscriminator Gender { get; set; }
        public int HealthInsuranceNumber { get; set; }
        public InsuranceTypeDiscriminator TypeOfInsurance { get; set; }
    }

    public enum InsuranceTypeDiscriminator
    {
        PRIVATE = 1,
        PUBLIC = 2
    }

    public enum GenderDiscriminator
    {
        MALE = 1,
        FEMALE = 2
    }
}
