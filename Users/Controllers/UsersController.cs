using DataLayer;
using Microsoft.AspNetCore.Mvc;

namespace Users.Controllers
{
    [ApiController]
    [Route("")]
    public class UsersController : ControllerBase
    {

        private IUserRepository userRepository;

        public UsersController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [HttpGet("users")]
        public async Task<IActionResult> Get()
        {
            return Ok(this.userRepository.GetAll());
        }

        [HttpGet("users/{id}")]
        public async Task<IActionResult> Get(int id)
        {

            User? user = this.userRepository.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            return base.Ok(user);
        }

        [HttpPost("users")]
        public async Task<IActionResult> Post(User user)
        {            
            return Ok(this.userRepository.Add(user));
        }

        [HttpPut("users")]
        public async Task<IActionResult>Update(User user)
        {
            User? userUpdated = this.userRepository.Update(user);
            if (userUpdated == null)
            {
                return NotFound();
            }
            return base.Ok(userUpdated);
        }

        [HttpDelete("users/{id}")]
        public async Task<IActionResult>Delete(int id)
        {
            User? user = this.userRepository.Delete(id);
            if (user == null)
            {
                return NotFound();
            }
            return base.Ok(user);
        }
    }
}
