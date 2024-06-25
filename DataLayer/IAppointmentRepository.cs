using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IAppointmentRepository
    {
        List<Appointment> Find(int userId,string start, string end);
        List<Appointment> GetAll();
        Appointment Add(Appointment appointment);
        Appointment Update(Appointment appointment);
    }
}
