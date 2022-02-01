using ClubeApi.Domain.Core.Interfaces.Repositories;
using ClubeApi.Domain.Core.Interfaces.Services;
using ClubeApi.Domain.Models;

namespace ClubeApi.Domain.Services.Services
{
    public class ServiceCategoria : IServiceCategoria
    {
        //Atributo de referência ao repositório para implementa-lo
        private readonly IRepositoryCategoria repository;

        //Construtor
        public ServiceCategoria(IRepositoryCategoria repository)
        {
            this.repository = repository;
        }

        public void Add(Categoria obj)
        {
            repository.Add(obj);
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }

        public IEnumerable<Categoria> GetAll()
        {
            return repository.GetAll();
        }

        public Categoria GetById(int id)
        {
            return repository.GetById(id);
        }

        public void Update(Categoria obj)
        {
            repository.Update(obj);
        }
    }
}
