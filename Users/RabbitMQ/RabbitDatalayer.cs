using DataLayer;
using Newtonsoft.Json;
using RabbitMQ;

namespace Users.RabbitMQ
{
    public class RabbitDatalayer : IRabbitDatalayer
    {
        private IRabbitMQRepository _userRepository;
        private IRabbitMQRepository _appointmentRepository;
        private IRabbitMQRepository _addressRepository;
        public RabbitDatalayer()
        {
            _userRepository = new RabbitMQRepository("adduser");
            _appointmentRepository = new RabbitMQRepository("appointment");
            _addressRepository = new RabbitMQRepository("address");
        }

        public Task<string> AdddressQueue(Address address)
        {
            return _addressRepository.CallAsync(JsonConvert.SerializeObject(address));
        }

        public Task<string> AppointmentQueue(Appointment appointment)
        {
            return _appointmentRepository.CallAsync(JsonConvert.SerializeObject(appointment));
        }

        public Task<string> UserQueue(User user)
        {
            return _userRepository.CallAsync(JsonConvert.SerializeObject(user));
        }
    }
}
