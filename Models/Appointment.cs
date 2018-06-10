using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebApplication1.Models
{
    public class Appointment
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string patientId { get; set; }
        public string practiseId { get; set; }
        public string appointmentDate { get; set; }
        public string time { get; set; }
        public string description { get; set; }
    }
}
