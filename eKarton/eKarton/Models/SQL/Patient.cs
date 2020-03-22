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
        PRIVATE,
        PUBLIC
    }

    public enum GenderDiscriminator
    {
        MALE,
        FEMALE
    }
}
