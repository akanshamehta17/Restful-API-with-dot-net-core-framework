using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebApplication1.Models
{
    public class Patient
    {   
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string patientId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string birthdate { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string medicalNotes { get; set; }
        public string nextVisitDate { get; set; }
        public string zip { get; set; }
        public string cell { get; set; }
        public string practiseId { get; set; }
    }
}
