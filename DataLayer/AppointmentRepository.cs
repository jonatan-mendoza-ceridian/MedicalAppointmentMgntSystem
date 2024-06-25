using Dapper;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private IDbConnection db;

        public AppointmentRepository()
        {
            this.db = this.createConnection();
        }
        public Appointment Add(Appointment appointment)
        {
            var id = this.db.Insert(appointment);
            appointment.Id = (int)id;
            return appointment;
        }

        public List<Appointment> Find(int userId, string start, string end)
        {
            var stringStart = start + " 00:00:00";
            var stringEnd = end + " 23:59:59";
            var sql = "SELECT * FROM appointment WHERE id_patient = @userId AND AppointmentDate BETWEEN CONVERT(datetime, @stringStart) AND CONVERT (datetime,@stringEnd)";
            return this.db.Query<Appointment>(sql,new { userId, stringStart, stringEnd }).ToList();
        }

        public List<Appointment> GetAll()
        {
            var appointments = this.db.GetAll<Appointment>();
            return appointments.ToList();
        }

        public Appointment Update(Appointment appointment)
        {
            throw new NotImplementedException();
        }
        private IDbConnection createConnection()
        {
            return new SqlConnection("Server=.;Database=TestDB;Trusted_Connection=True;MultipleActiveResultSets=true;Integrated Security=False;User ID=sa; Password=Test123456@");
        }
    }
}
