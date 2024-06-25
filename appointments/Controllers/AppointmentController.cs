using DataLayer;
using Microsoft.AspNetCore.Mvc;

namespace appointments.Controllers
{
    [ApiController]
    [Route("")]
    public class AppointmentController : ControllerBase
    {
        private IAppointmentRepository appointmentRepository;

        public AppointmentController(IAppointmentRepository appointmentRepository)
        {
            this.appointmentRepository = appointmentRepository;
        }

        [HttpGet("appointment")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(this.appointmentRepository.GetAll());
        }
        [HttpGet("appointment/{id}/{start}/{end}")]
        public async Task<IActionResult>Get(int id,string start,string end)
        {
            return Ok(this.appointmentRepository.Find(id,start,end)); 
        }
        [HttpPost("appointment")]
        public async Task<IActionResult> AddAppointment(Appointment appointment)
        {
            return Ok(this.appointmentRepository.Add(appointment));
        }
    }
}
