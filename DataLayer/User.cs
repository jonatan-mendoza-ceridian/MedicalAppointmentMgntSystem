using Dapper.Contrib.Extensions;

namespace DataLayer
{
    [Table("patients")]
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public Address address  { get; set; }
        [Write(false)]
        public List<Appointment>? Appointments { get; set; }
        
    }
}
