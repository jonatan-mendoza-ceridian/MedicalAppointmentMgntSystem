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
        public User Add(User user)
        {
            var id = this.db.Insert(user);
            user.Id = (int)id;
            return user;
        }

        public User Delete(int id)
        {
            User? user = this.db.Get<User>(id);
            if(user != null)
            {
                this.db.Delete(new User { Id = id});
            }
            return user;
        }

        public User Find(int id)
        {
            return this.db.Get<User>(id);
        }

        public List<User> GetAll()
        {
            return this.db.GetAll<User>().ToList();
        }

        public User Update(User user)
        {
            this.db.Update(user);
            return user;
        }
        private IDbConnection createConnection()
        {
            return new SqlConnection("Server=.;Database=TestDB;Trusted_Connection=True;MultipleActiveResultSets=true;Integrated Security=False;User ID=sa; Password=Test123456@");
        }
    }
}
