using ClubeApi.Domain.Core.Interfaces.Repositories;
using ClubeApi.Domain.Core.Interfaces.Services;

namespace ClubeApi.Domain.Services.Services
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : class
    {
        //Atributo de referência ao repositório para implementa-lo
        private readonly IRepositoryBase<TEntity> repository;

        //Construtor
        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            this.repository = repository;
        }

        public void Add(TEntity obj)
        {
            repository.Add(obj);
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return repository.GetAll();
        }

        public TEntity GetById(int id)
        {
            return repository.GetById(id);
        }

        public void Update(TEntity obj)
        {
            repository.Update(obj);
        }
    }
}
