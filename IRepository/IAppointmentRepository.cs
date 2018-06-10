using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.IRepository
{
    public interface IAppointmentRepository
    {
        Task<IEnumerable<Appointment>> Get();
        Task<Appointment> Get(string id);
        Task Add(Appointment appointment);
        Task<string> Update(string id, Appointment appointment);
        Task<DeleteResult> Remove(string id);
        Task<DeleteResult> RemoveAll();
    }
}
