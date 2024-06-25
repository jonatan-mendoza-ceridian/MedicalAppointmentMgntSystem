using Dapper;
using Dapper.Contrib.Extensions;
using System.Data;
using System.Data.SqlClient;

namespace DataLayer
{
    public class UserRepositoryContrib : IUserRepository
    {
        private IDbConnection db;

        public UserRepositoryContrib()
        {
            this.db = this.createConnection();
        }
        public async Task<User> Add(User user)
        {
            var id = this.db.Insert(user);
            user.Id = (int)id;
            return user;
        }

        public async Task<User> Delete(int id)
        {
            User? user = await this.db.GetAsync<User>(id);
            if(user != null)
            {
                this.db.Delete(new User { Id = id});
            }
            return user;
        }

        public async Task<User> Find(int id)
        {
            var sql = "SELECT * FROM patients WHERE Id = @Id;" +
                "SELECT * FROM appointment WHERE id_patient = @Id";
            using (var multipleResults = await this.db.QueryMultipleAsync(sql, new { Id = id }))
            {
                var patient= multipleResults.Read<User>().SingleOrDefault();
                var appointments = multipleResults.Read<Appointment>().ToList();
                if(patient != null) {
                    if(appointments != null)
                    {
                        patient.Appointments=appointments;
                    }                    
                }
                return patient;
            }                
        }

        public List<User> GetAll()
        {
            var users  = this.db.GetAll<User>();
            return users.ToList();
        }

        public async Task<User> Update(User user)
        {
            this.db.UpdateAsync(user);

            return await this.Find(user.Id);
        }
        private IDbConnection createConnection()
        {
            return new SqlConnection("Server=.;Database=TestDB;Trusted_Connection=True;MultipleActiveResultSets=true;Integrated Security=False;User ID=sa; Password=Test123456@");
        }
    }
}
