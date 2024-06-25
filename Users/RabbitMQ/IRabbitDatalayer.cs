using DataLayer;

namespace Users.RabbitMQ
{
    public interface IRabbitDatalayer
    {
        public Task<string> UserQueue(User user);
        public Task<string> AdddressQueue(Address address);
        public Task<string> AppointmentQueue(Appointment appointment);
    }
}