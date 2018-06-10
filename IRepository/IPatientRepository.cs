using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.IRepository
{
    public interface IPatientRepository
    {
        Task<IEnumerable<Patient>> Get();
        Task<Patient> Get(string id);
        Task Add(Patient patient);
        Task<string> Update(string id, Patient patient);
        Task<DeleteResult> Remove(string id);
        Task<DeleteResult> RemoveAll();
    }
}
