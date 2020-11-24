using Code.Database.Base;
using Code.Database.Context;
using Code.Model;
using Code.Repository;
using System.Collections.Generic;
using System.Linq;

namespace Code.Database
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public BPKTechContext BPKTechContext
        {
            get { return DatabaseContext as BPKTechContext; }
        }

        public UserRepository(BPKTechContext context) : base(context)
        {
        }

        public IEnumerable<User> GetUsers(string orderBy, string sortBy)
        {
            var users = BPKTechContext.Users.ToList();
            switch (orderBy)
            {
                case "LastName":
                    users = sortBy == "asc" ? users.OrderBy(x => x.LastName).ToList() : users.OrderByDescending(x => x.LastName).ToList();
                    break;

                case "FirstName":
                    users = sortBy == "asc" ? users.OrderBy(x => x.FirstName).ToList() : users.OrderByDescending(x => x.FirstName).ToList();
                    break;

                default:
                    users = users.OrderBy(x => x.LastName).ToList();
                    break;
            }
            return users;
        }
    }
}