using ClubeApi.Domain.Core.Interfaces.Repositories;
using ClubeApi.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ClubeApi.Infrastructure.Data.Repositories
{
    public class RepositorySocio : RepositoryBase<Socio>, IRepositorySocio
    {
        //Atributo de contexto para controle do banco
        private readonly SqlDbContext context;

        //Construtor
        public RepositorySocio(SqlDbContext context) : base(context)
        {
            this.context = context;
        }

        public override IEnumerable<Socio> GetAll()
        {
            try
            {
                return context.Socios.Include("Categoria").ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override Socio GetById(int id)
        {
            try
            {
                IEnumerable<Socio> socios = context.Socios.Include("Categoria").ToList();
                Socio socio = new Socio();
                foreach(Socio s in socios)
                {
                    if(s.Id == id)
                        socio = s;
                }

                return socio;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
