using DellChallenge.Domain.Enitities;
using DellChallenge.Domain.Interfaces.Repositories;


namespace DellChallenge.Domain.Interfaces
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        User Find(User user);
    }
}
