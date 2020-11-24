using Code.Repository.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Code.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BaseController<TModel, TRepository> : ControllerBase where TModel : class where TRepository : IRepository<TModel>
    {
        protected readonly TRepository Repository;

        public BaseController(TRepository repository)
        {
            this.Repository = repository;
        }

        /// <summary>
        /// This API call will create a record at the database.
        /// </summary>
        /// <param name="item">Model object to post</param>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public void Add([FromBody] TModel item)
        {
            Repository.Add(item);
            Repository.Save();
        }

        /// <summary>
        /// This API call will return a record from the database.
        /// </summary>
        /// <param name="id">1</param>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public void Get(int id)
        {
            Repository.Get(id);
        }

        /// <summary>
        /// This API call will update a record at the database.
        /// </summary>
        /// <param name="item">Model object to post</param>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public void Update([FromBody] TModel item)
        {
            Repository.Update(item);
            Repository.Save();
        }

        /// <summary>
        /// This API call will delete a record at the database.
        /// </summary>
        /// <param name="id">Record Id</param>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public void Delete(int id)
        {
            Repository.Remove(id);
            Repository.Save();
        }
    }
}