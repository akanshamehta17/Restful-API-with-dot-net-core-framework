using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.DBModels
{
    public class ObjectContext
    {
        public IConfigurationRoot Configuration { get; }
        private IMongoDatabase _database = null;

        public ObjectContext(IOptions<Settings> settings)
        {
            Configuration = settings.Value.iConfigurationRoot;
            settings.Value.ConnectionString = Configuration.GetSection("MongoConnection:ConnectionString").Value;
            settings.Value.Database = Configuration.GetSection("MongoConnection:Database").Value;

            var client = new MongoClient(settings.Value.ConnectionString);

            /*..Get Database name..*/
            if (client != null)
            {
                _database = client.GetDatabase(settings.Value.Database);
            }


        }

        /*..Get Collection names..*/
        public IMongoCollection<Patient> Patients
        {
            get
            {
                return _database.GetCollection<Patient>("Patient");
            }
        }

        public IMongoCollection<Practice> Practice
        {
            get
            {
                return _database.GetCollection<Practice>("Practice");
            }
        }

        public IMongoCollection<Appointment> Appointment
        {
            get
            {
                return _database.GetCollection<Appointment>("Appointment");
            }
        }

    }
}
