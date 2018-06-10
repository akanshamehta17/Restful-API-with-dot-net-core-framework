using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.IRepository;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    public class PracticesController
    {

        private readonly IPracticeRepository _practiceRepository;

        public PracticesController(IPracticeRepository practiceRepository)
        {
            _practiceRepository = practiceRepository;
        }

        //Get Practice details
        [HttpGet]
        public Task<string> Get()
        {
            return this.GetPractice();
        }

        private async Task<string> GetPractice()
        {
            var practice = await _practiceRepository.Get();
            return JsonConvert.SerializeObject(practice);
        }

        //Filter Practice details by Practice ID
        [HttpGet("{id}")]
        public Task<string> Get(string Id)
        {
            return this.GetPracticeById(Id);
        }

        private async Task<string> GetPracticeById(string Id)
        {
            var practice = await _practiceRepository.Get(Id) ?? new Practice();
            return JsonConvert.SerializeObject(practice);
        }

        //Create Practice Data       
        [HttpPost]
        public async Task<string> Post([FromBody] Practice practice)
        {
            await _practiceRepository.Add(practice);
            return "";
        }

        //Update Practice Data by Practice Id
        [HttpPut("{id}")]
        public async Task<string> Put(string id, [FromBody] Practice practice)
        {
            if (string.IsNullOrEmpty(id)) return "Invalid Id !!!";
            return await _practiceRepository.Update(id, practice);

        }

        //Delete Practice Data by Practice Id
        [HttpDelete("{id}")]
        public async Task<string> Delete(string id)
        {
            if (string.IsNullOrEmpty(id)) return "Invalid Id !!!";
            await _practiceRepository.Remove(id);
            return "";
        }
    }
}
