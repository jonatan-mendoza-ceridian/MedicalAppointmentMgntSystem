namespace DataLayer
{
    public interface IUserRepository
    {
        Task<User> Find(int id);
        List<User> GetAll();
        Task<User> Add(User user);
        Task<User> Update(User user);
        Task<User> Delete(int id);

    }
}
