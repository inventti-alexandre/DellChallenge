using DellChallenge.Domain.Enitities;
using DellChallenge.Domain.Interfaces.Repositories;
using System.Collections.Generic;

namespace DellChallenge.Domain.Interfaces
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        User Find(User user);
        List<User> ListSeller();
    }
}
