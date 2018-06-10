using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DBModels;
using WebApplication1.IRepository;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class PatientRepository : IPatientRepository
    {
        private readonly ObjectContext _context = null;

        public PatientRepository(IOptions<Settings> settings)
        {
            _context = new ObjectContext(settings);

        }

        public async Task Add(Patient patient)
        {
            await _context.Patients.InsertOneAsync(patient);
        }

        public async Task<IEnumerable<Patient>> Get()
        {
            return await _context.Patients.Find(x => true).ToListAsync();
        }

        public async Task<Patient> Get(string id)
        {
            var patient = Builders<Patient>.Filter.Eq("patientId", id);
            return await _context.Patients.Find(patient).FirstOrDefaultAsync();
        }

        public async Task<DeleteResult> Remove(string id)
        {
            return await _context.Patients.DeleteOneAsync(Builders<Patient>.Filter.Eq("patientId", id));
        }

        public async Task<DeleteResult> RemoveAll()
        {
            return await _context.Patients.DeleteManyAsync(new BsonDocument());
        }

        public async Task<string> Update(string id, Patient patient)
        {
            await _context.Patients.ReplaceOneAsync(zz => zz.patientId == id, patient);
            return "";

        }
    }
}
