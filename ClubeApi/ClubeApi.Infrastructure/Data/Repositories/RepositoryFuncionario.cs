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
            try
            {
                context.Set<Funcionario>().Add(obj);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(int id)
        {
            try
            {
                Funcionario obj = context.Set<Funcionario>().Find(id);
                context.Remove(obj);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Funcionario GetById(int id)
        {
            try
            {
                return context.Set<Funcionario>().Single(f => f.Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(Funcionario obj)
        {
            try
            {
                context.Update(obj);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Validate(string usuario, string senha)
        {
            try
            {
                Funcionario obj2 = context.Set<Funcionario>().Where(f => f.Usuario.Equals(usuario) && f.Senha.Equals(senha)).Single();
                if (obj2 == null)
                    return 0;
                else
                    return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
