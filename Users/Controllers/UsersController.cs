using DataLayer;
using Microsoft.AspNetCore.Mvc;
using Users.RabbitMQ;

namespace Users.Controllers
{
    [ApiController]
    [Route("")]
    public class UsersController : ControllerBase
    {

        private IUserRepository userRepositoryContrib;

        private IRabbitDatalayer _rabbitDataLayer;

        public UsersController(IUserRepository userRepositoryContrib, IRabbitDatalayer _rabbitDataLayer)
        {
            this.userRepositoryContrib = userRepositoryContrib;
            this._rabbitDataLayer = _rabbitDataLayer;
        }

        [HttpGet("users")]
        public async Task<IActionResult> Get()
        {
            return Ok(this.userRepositoryContrib.GetAll());
        }

        [HttpGet("users/{id}")]
        public async Task<IActionResult> Get(int id)
        {

            User? user = await this.userRepositoryContrib.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            return base.Ok(user);
        }

        [HttpPost("users")]
        public async Task<IActionResult> AddUser(User user)
        {
            var value = await this._rabbitDataLayer.UserQueue(user);
            return base.Ok(value);
            //return Ok(this.userRepositoryContrib.Add(user));
        }

        [HttpPut("users")]
        public async Task<IActionResult>Update(User user)
        {
            User? userUpdated = await this.userRepositoryContrib.Update(user);
            if (userUpdated == null)
            {
                return NotFound();
            }
            return base.Ok(userUpdated);
        }

        [HttpPut("appointment")]
        public async Task<IActionResult> createAppointment(Appointment appointment )
        {
            var value = await this._rabbitDataLayer.AppointmentQueue(appointment);
            return base.Ok(value);
        }

        [HttpPatch("address")]
        public async Task<IActionResult> updateAddress(Address address)
        {
            var value = await this._rabbitDataLayer.AdddressQueue(address);
            return base.Ok(value);
        }

    }
}
