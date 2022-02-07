using ClubeApi.Domain.Core.Interfaces.Repositories;
using ClubeApi.Domain.Core.Interfaces.Services;
using ClubeApi.Domain.Models;

namespace ClubeApi.Domain.Services.Services
{
    public class ServiceFuncionario : IServiceFuncionario
    {
        //Atributo de referência ao repositório para implementa-lo
        private readonly IRepositoryFuncionario repository;

        //Construtor
        public ServiceFuncionario(IRepositoryFuncionario repository)
        {
            this.repository = repository;
        }

        public int Add(Funcionario obj)
        {
            return repository.Add(obj);
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }

        public Funcionario GetById(int id)
        {
            return repository.GetById(id);
        }

        public void Update(Funcionario obj)
        {
            repository.Update(obj);
        }

        public int Validate(string usuario, string senha)
        {
            return repository.Validate(usuario, senha);
        }
    }
}
