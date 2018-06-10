using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebApplication1.Models
{
    public class Practice
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string practiceId { get; set; }
        public string practiceName { get; set; }
        public string speciality { get; set; }
        public string licenseNumber { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        //public string medicalNotes { get; set; }
        //public string nextVisitDate { get; set; }
        public string zip { get; set; }
        public string cell { get; set; }
        
    }
}
