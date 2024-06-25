
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace DataLayer
{
    public class UserRepository 
    {
        private IDbConnection db;

        public UserRepository()
        {
            this.db = this.createConnection();
        }
        public User Add(User user)
        {
            var sql = "INSERT INTO [User] (Name,Email,FirstName,LastName) VALUES (@Name,@Email,@FirstName,@Lastname);"+
                "SELECT CAST(SCOPE_IDENTITY() as int)";
            var id  = this.db.Query<int>(sql,user).Single();
            user.Id = id;
            return user;
        }

        public User Delete(int id)
        {
            User? user = this.Find(id);
            if(user != null) {
                var sql = "DELETE FROM [User] WHERE Id=@Id";
                this.db.Execute(sql, new{ id });
            }
            return user;
        }

        public User Find(int id)
        {
            return this.db.Query<User>("SELECT * FROM [User] WHERE Id = @Id", new { id }).SingleOrDefault();        
        }

        public List<User> GetAll()
        {
            //this.db = this.createConnection();
            return this.db.Query<User>("SELECT * FROM [User]").ToList();
        }

        public User Update(User user)
        {            
            var sql  = "UPDATE [User] "+
                       "SET Name = @Name, "+
                       "    Email = @Email, " +
                       "    FirstName = @FirstName, " +
                       "    LastName = @LastName "+
                       "WHERE Id = @Id";
            this.db.Execute(sql, user);
            return user;
        }

        private IDbConnection createConnection() { 
               return new SqlConnection("Server=.;Database=TestDB;Trusted_Connection=True;MultipleActiveResultSets=true;Integrated Security=False;User ID=sa; Password=Test123456@");
        }
    }
}
