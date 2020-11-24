using System.Collections.Generic;

namespace Code.Repository.Base
{
    public interface IRepository<TModel> where TModel : class
    {
        TModel Get(int id);

        IEnumerable<TModel> GetAll();

        void Add(TModel entity);

        void Update(TModel entity);

        void Remove(int id);

        void Save();
    }
}