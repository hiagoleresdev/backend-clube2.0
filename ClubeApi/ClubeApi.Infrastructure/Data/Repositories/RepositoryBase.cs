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
        public virtual int Verify(TEntity entity)
        {
            TEntity entity1 = context.Set<TEntity>().Where(t => t.Equals(entity)).FirstOrDefault();
            if(entity1 == null)
                return 0;
            else
                return 1;
        }

        public int Add(TEntity obj)
        {
            int verificar = Verify(obj);

            if (verificar == 0)
            {
                context.Set<TEntity>().Add(obj);
                context.SaveChanges();
                return 1;
            }
            else
                return 0;
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
