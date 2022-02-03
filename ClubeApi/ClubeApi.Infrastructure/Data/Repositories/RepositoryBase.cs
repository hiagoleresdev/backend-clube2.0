using ClubeApi.Domain.Core.Interfaces.Repositories;

namespace ClubeApi.Infrastructure.Data.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        //Atributo de contexto para controle do banco
        private readonly SqlDbContext context;

        //Construtor
        public RepositoryBase(SqlDbContext context)
        {
            this.context = context;
        }

        //Métodos da interface
        public void Add(TEntity obj)
        {
            context.Set<TEntity>().Add(obj);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            TEntity obj = context.Set<TEntity>().Find(id);
            context.Set<TEntity>().Remove(obj);
            context.SaveChanges();
        }

        public virtual TEntity GetById(int id)
        {
            return context.Set<TEntity>().Find(id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return context.Set<TEntity>().ToList();
        }

        public void Update(TEntity obj)
        {
            context.Set<TEntity>().Update(obj);
            context.SaveChanges();
        }
    }
}
