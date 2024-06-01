namespace DataLayer
{
    public class Appointment
    {
        public int id;
        public DateTime Date { get; set; }
        public Boolean IsConfirmed { get; set; }
        public Boolean IsAssisted { get; set; }
    }
}
