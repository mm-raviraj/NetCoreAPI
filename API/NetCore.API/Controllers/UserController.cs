using Code.Database;
using Code.Model;
using Code.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Code.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : BaseController<User, UserRepository>
    {
        public UserController(UserRepository repository) : base(repository)
        {
        }

        /// <summary>
        /// The method will return the user list based on the OrderBy and SortBy details provided.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /User/LastName/asc
        ///
        /// </remarks>
        /// <param name="orderBy">"FirstName" or "LastName"</param>
        /// <param name="sortBy">"asc" or "desc"</param>
        /// <returns></returns>
        [HttpGet("{orderBy}/{sortBy}")]
        public IEnumerable<User> GetUsers(string orderBy = "LastName", string sortBy = "asc")
        {
            return Repository.GetUsers(orderBy, sortBy);
        }
    }
}