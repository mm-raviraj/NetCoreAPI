using Code.Model;
using Code.Repository.Base;
using System.Collections.Generic;

namespace Code.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        IEnumerable<User> GetUsers(string orderBy, string sortBy);
    }
}