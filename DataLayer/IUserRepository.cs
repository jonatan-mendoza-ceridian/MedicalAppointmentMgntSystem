namespace DataLayer
{
    public interface IUserRepository
    {
        User Find(int id);
        List<User> GetAll();
        User Add(User user);
        User Update(User user);
        User Delete(int id);

    }
}
