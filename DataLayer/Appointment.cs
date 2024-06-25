using Dapper.Contrib.Extensions;
using System.ComponentModel;

namespace DataLayer
{
    [Table("appointment")]
    public class Appointment
    {
        public int Id { get; set; }
        public DateTime AppointmentDate { get; set; }
        public Boolean IsConfirmed { get; set; }
        public Boolean IsAssisted { get; set; }
       
        public int Id_Patient { get; set; }
    }
}
