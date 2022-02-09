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

        public int Verify(Funcionario funcionario)
        {
            Funcionario funcionario1 = context.Funcionarios.Where(f => f.Usuario.Equals(funcionario.Usuario)).FirstOrDefault();
            Funcionario funcionario2 = context.Funcionarios.Where(f => f.Senha.Equals(funcionario.Senha)).FirstOrDefault();

            if (funcionario1 == null && funcionario2 == null)
                return 0;
            else
                return 1;
        }

        public int Add(Funcionario funcionario)
        {
            int verificar = Verify(funcionario);

            if (verificar == 0)
            {
                context.Set<Funcionario>().Add(funcionario);
                context.SaveChanges();
                return 1;
            }
            else
                return 0;
        }

        public int Delete(int id)
        {
            Funcionario obj = context.Funcionarios.Find(id);
            if (obj != null)
            {
                context.Funcionarios.Remove(obj);
                context.SaveChanges();
                return 1;
            }
            else
                return 0;
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
