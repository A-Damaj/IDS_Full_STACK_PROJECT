using WebApplicationfin.Models;

namespace WebApplicationfin.repositories
{
    public interface IUserRepository
    {
        User GetById(int id);
        IEnumerable<User> GetAll();
        void Insert(User user);
        void Update(User user);
        void Delete(User user);
    }

}
