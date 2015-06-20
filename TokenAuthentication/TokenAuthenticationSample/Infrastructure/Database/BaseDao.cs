using NPoco;
using RestSample.Server.Model;

namespace RestSample.Server.Services
{
    public class BaseDao<TEntity> : IDao<TEntity>
        where TEntity : Entity
    {
        protected IDatabase Database { get; set; }

        protected BaseDao(IDatabase database)
        {
            Database = database;
        }

        public TEntity Insert(TEntity entity)
        {
            return Database.Insert(entity) as TEntity;
        }

        public TEntity Get(int id)
        {
            return Database.Query<TEntity>().FirstOrDefault(x => x.Id == id);
        }

        public TEntity Update(TEntity entity)
        {
            Database.Update(entity);

            return entity;
        }

        public void Delete(TEntity entity)
        {
            Database.Delete<TEntity>(entity);
        }
    }
}