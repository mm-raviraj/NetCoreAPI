using Code.Repository.Base;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Code.Database.Base
{
    public abstract class Repository<TModel> : IRepository<TModel> where TModel : class
    {
        protected readonly DbContext DatabaseContext;

        public Repository(DbContext context)
        {
            this.DatabaseContext = context;
        }

        public void Add(TModel entity)
        {
            DatabaseContext.Set<TModel>().Add(entity);
        }

        public void Update(TModel entity)
        {
            DatabaseContext.Set<TModel>().Update(entity);
        }

        public TModel Get(int id)
        {
            return DatabaseContext.Set<TModel>().Find(id);
        }

        public IEnumerable<TModel> GetAll()
        {
            return DatabaseContext.Set<TModel>().ToList();
        }

        public void Remove(int id)
        {
            var model = DatabaseContext.Set<TModel>().Find(id);
            DatabaseContext.Set<TModel>().Remove(model);
        }

        public void Save()
        {
            DatabaseContext.SaveChanges();
        }
    }
}