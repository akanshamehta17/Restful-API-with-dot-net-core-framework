using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.IRepository
{
    public interface IPracticeRepository
    {
        Task<IEnumerable<Practice>> Get();
        Task<Practice> Get(string id);
        Task Add(Practice patient);
        Task<string> Update(string id, Practice practice);
        Task<DeleteResult> Remove(string id);
        Task<DeleteResult> RemoveAll();
    }
}
