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
    public class PracticeRepository : IPracticeRepository
    {
        private readonly ObjectContext _context = null;

        public PracticeRepository(IOptions<Settings> settings)
        {
            _context = new ObjectContext(settings);

        }

        public async Task Add(Practice practice)
        {
            await _context.Practice.InsertOneAsync(practice);
        }

        public async Task<IEnumerable<Practice>> Get()
        {
            return await _context.Practice.Find(x => true).ToListAsync();
        }

        public async Task<Practice> Get(string id)
        {
            var practice = Builders<Practice>.Filter.Eq("practiceId", id);
            return await _context.Practice.Find(practice).FirstOrDefaultAsync();
        }

        public async Task<DeleteResult> Remove(string id)
        {
            return await _context.Practice.DeleteOneAsync(Builders<Practice>.Filter.Eq("practiceId", id));
        }

        public async Task<DeleteResult> RemoveAll()
        {
            return await _context.Practice.DeleteManyAsync(new BsonDocument());
        }

        public async Task<string> Update(string id, Practice practice)
        {
            await _context.Practice.ReplaceOneAsync(zz => zz.practiceId == id, practice);
            return "";

        }
    }
}
