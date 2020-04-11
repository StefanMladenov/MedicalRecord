using System.ComponentModel.DataAnnotations;

namespace eMedicalRecord.Models.SQL
{
    public class Medicine : AbstractEntity
    {
        [Required]
        public string NameOfMedicine { get; set; }
        public bool Allergic { get; set; }
    }
}