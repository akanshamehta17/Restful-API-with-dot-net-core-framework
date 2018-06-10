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
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly ObjectContext _context = null;

        public AppointmentRepository(IOptions<Settings> settings)
        {
            _context = new ObjectContext(settings);

        }

        public async Task Add(Appointment appointment)
        {
            await _context.Appointment.InsertOneAsync(appointment);
        }

        public async Task<IEnumerable<Appointment>> Get()
        {
            return await _context.Appointment.Find(x => true).ToListAsync();
        }

        public async Task<Appointment> Get(string id)
        {
            var appointment = Builders<Appointment>.Filter.Eq("Id", id);
            return await _context.Appointment.Find(appointment).FirstOrDefaultAsync();
        }

        public async Task<DeleteResult> Remove(string id)
        {
            return await _context.Appointment.DeleteOneAsync(Builders<Appointment>.Filter.Eq("Id", id));
        }

        public async Task<DeleteResult> RemoveAll()
        {
            return await _context.Appointment.DeleteManyAsync(new BsonDocument());
        }

        public async Task<string> Update(string id, Appointment appointment)
        {
            await _context.Appointment.ReplaceOneAsync(zz => zz.Id == id, appointment);
            return "";

        }
    }
}
