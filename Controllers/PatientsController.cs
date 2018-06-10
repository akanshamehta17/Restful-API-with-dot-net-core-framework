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
    public class PatientsController
    {
        
        private readonly IPatientRepository _patientRepository;

        public PatientsController(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        //Get Patient's details
        [HttpGet]
        public Task<string> Get()
        {
            return this.GetPatient();
        }

        private async Task<string> GetPatient()
        {
            var patients = await _patientRepository.Get();
            return JsonConvert.SerializeObject(patients);
        }

        //Filter Patients by Patient Id
        [HttpGet("{id}")]
        public Task<string> Get(string Id)
        {
            return this.GetPatientById(Id);
        }

        private async Task<string> GetPatientById(string Id)
        {
            var patient = await _patientRepository.Get(Id) ?? new Patient();
            return JsonConvert.SerializeObject(patient);
        }

        //Create Patient's data
        [HttpPost]
        public async Task<string> Post([FromBody] Patient patient)
        {
            await _patientRepository.Add(patient);
            return "";
        }

        //Update Patient's details
        [HttpPut("{id}")]
        public async Task<string> Put(string id, [FromBody] Patient patient)
        {
            if (string.IsNullOrEmpty(id)) return "Invalid Id !!!";
            return await _patientRepository.Update(id, patient);

        }

        //Delete Patient's data
        [HttpDelete("{id}")]
        public async Task<string> Delete(string id)
        {
            if (string.IsNullOrEmpty(id)) return "Invalid Id !!!";
            await _patientRepository.Remove(id);
            return "";
        }
    }
}
