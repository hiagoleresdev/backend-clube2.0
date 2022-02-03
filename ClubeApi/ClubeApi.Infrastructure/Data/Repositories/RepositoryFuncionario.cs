using ClubeApi.Domain.Core.Interfaces.Repositories;
using ClubeApi.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ClubeApi.Infrastructure.Data.Repositories
{
    public class RepositoryFuncionario : IRepositoryFuncionario
    {
        //Atributo de contexto para controle do banco
        private readonly SqlDbContext context;

        //Construtor
        public RepositoryFuncionario(SqlDbContext context)
        {
            this.context = context;
        }

        public void Add(Funcionario obj)
        {
            context.Set<Funcionario>().Add(obj);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            Funcionario obj = context.Set<Funcionario>().Find(id);
            context.Remove(obj);
            context.SaveChanges();
        }

        public Funcionario GetById(int id)
        {
            return context.Set<Funcionario>().Single(f => f.Id == id);
        }

        public void Update(Funcionario obj)
        {
            context.Update(obj);
            context.SaveChanges();
        }

        public int Validate(string usuario, string senha)
        {
            Funcionario obj2 = context.Set<Funcionario>().Where(f => f.Usuario.Equals(usuario) && f.Senha.Equals(senha)).FirstOrDefault();
            if (obj2 == null)
                return 0;
            else
                return 1;
        }
    }
}
