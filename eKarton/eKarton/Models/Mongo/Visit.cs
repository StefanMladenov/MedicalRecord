using eKarton.Models.SQL;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eKarton.Models
{
    public class Visit
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public string Guid { get; set; } = System.Guid.NewGuid().ToString();
        
        [BsonElement("Therapy")]
        public string Therapy { get; set; }
        
        [BsonElement("UpdatedDate")]
        [BsonDateTimeOptions]
        public DateTime UpdatedOn { get; set; } = DateTime.Now;
        
        [BsonElement("CreatedDate")]
        [BsonDateTimeOptions]
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        [BsonElement("DoctorUCIN")]
        public string DoctorUCIN { get; set; }

        [BsonElement("PatientUCIN")]
        public string PatientUCIN { get; set; }

        [BsonElement("WorkingDiagnosis")]
        public string WorkingDiagnosis { get; set; }
        
        [BsonElement("CurrentFinding")]
        public string CurrentFinding { get; set; }

        [BsonElement("FilePaths")]
        public string[] FilePaths { get; set; } 
    }
}
