namespace DataLayer
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }  
        //public Address address  { get; set; }
        public List<Appointment> Appointments { get; set; }
        
    }
}
