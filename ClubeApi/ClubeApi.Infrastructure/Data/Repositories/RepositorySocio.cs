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

        public override int Verify(Socio socio)
        {
            Pessoa pessoa = context.Pessoas.Where(p => p.Nome.Equals(socio.Nome)).FirstOrDefault();
            if(pessoa == null) 
                return 0;
            else
                return 1;
        }

        public override IEnumerable<Socio> GetAll()
        {
            return context.Socios.Include("Categoria").ToList();
        }

        public override Socio GetById(int id)
        {
            IEnumerable<Socio> socios = context.Socios.Include("Categoria").ToList();
            Socio socio = new Socio();
            foreach (Socio s in socios)
            {
                if (s.Id == id)
                    socio = s;
            }

            return socio;
        }

        public override int Delete(int id)
        {
            int x = 0;
            IEnumerable<Mensalidade> mensalidades = context.Mensalidades.Include("Socio").ToList();
            foreach(Mensalidade m in mensalidades)
            {
                if(m.Socio.Id == id)
                {
                    if(m.Quitada)
                        x++;
                }
            }
            if (x == 0)
            {
                Socio socio = context.Socios.Find(id);
                if (socio != null)
                {
                    context.Socios.Remove(socio);
                    context.SaveChanges();
                    return 1;
                }
                else
                    return -1;
            }
            else
                return 0;
        }
    }
}
