using DellChallenge.Domain.Enitities;
using DellChallenge.Domain.Interfaces;
using DellChallange.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DellChallange.Repository.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(DellContext kondominiumContext) : base(kondominiumContext)
        {
        }

        public User Find(User user)
        {
            return DbSet.FirstOrDefault(x => x.Email.Equals(user.Email) && x.Password.Equals(user.Password));
        }
    }
}
