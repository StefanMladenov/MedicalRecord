using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace eKarton.Models
{
    public class Visit
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Therapy")]
        public string Therapy { get; set; }

        [BsonElement("UpdatedDate")]
        public DateTime UpdatedOn { get; set; } = DateTime.Now;

        [BsonElement("CreatedDate")]
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        [BsonElement("DoctorUCIN")]
        [StringLength(13,MinimumLength = 13)]
        public string DoctorUCIN { get; set; }
        
        [BsonElement("PatientUCIN")]
        [StringLength(13, MinimumLength = 13)]
        [Required]
        public string PatientUCIN { get; set; }

        [BsonElement("WorkingDiagnosis")]                                          
        public string WorkingDiagnosis { get; set; }

        [BsonElement("CurrentFinding")]
        public string CurrentFinding { get; set; }

        [BsonElement("FilePaths")]
        public string[] FilePaths { get; set; }
        
        [BsonElement("MedicalRecordGuid")]
        [Required]
        public string MedicalRecordGuid { get; set; }

        [BsonElement("Guid")]
        public string Guid { get; set;  } = System.Guid.NewGuid().ToString();
    }
}
