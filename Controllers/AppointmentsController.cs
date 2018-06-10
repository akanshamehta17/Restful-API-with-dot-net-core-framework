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
    public class AppointmentsController
    {

        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentsController(IAppointmentRepository AppointmentRepository)
        {
            _appointmentRepository = AppointmentRepository;
        }

        //Get Appointment details
        [HttpGet]
        public Task<string> Get()
        {
            return this.GetAppointment();
        }

        private async Task<string> GetAppointment()
        {
            var appointment = await _appointmentRepository.Get();
            return JsonConvert.SerializeObject(appointment);
        }

        //Get appointment details by appointment id
        [HttpGet("{id}")]
        public Task<string> Get(string Id)
        {
            return this.GetAppointmentById(Id);
        }

        private async Task<string> GetAppointmentById(string Id)
        {
            var appointment = await _appointmentRepository.Get(Id) ?? new Appointment();
            return JsonConvert.SerializeObject(appointment);
        }


        //Create appointment
        [HttpPost]
        public async Task<string> Post([FromBody] Appointment appointment)
        {
            await _appointmentRepository.Add(appointment);
            return "";
        }

        //Update appointment
        [HttpPut("{id}")]
        public async Task<string> Put(string id, [FromBody] Appointment appointment)
        {
            if (string.IsNullOrEmpty(id)) return "Invalid Id !!!";
            return await _appointmentRepository.Update(id, appointment);

        }

        //Delete appointment
        [HttpDelete("{id}")]
        public async Task<string> Delete(string id)
        {
            if (string.IsNullOrEmpty(id)) return "Invalid Id !!!";
            await _appointmentRepository.Remove(id);
            return "";
        }
    }
}
