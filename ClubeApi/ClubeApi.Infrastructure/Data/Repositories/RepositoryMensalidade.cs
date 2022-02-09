using ClubeApi.Domain.Core.Interfaces.Repositories;
using ClubeApi.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ClubeApi.Infrastructure.Data.Repositories
{
    public class RepositoryMensalidade : RepositoryBase<Mensalidade>, IRepositoryMensalidade
    {
        //Atributo de contexto para controle do banco
        private readonly SqlDbContext context;

        //Construtor
        public RepositoryMensalidade(SqlDbContext context) : base(context)
        {
            this.context = context;
        }

        public override int Verify(Mensalidade mensalidade)
        {
            Mensalidade mensalidade1 = context.Mensalidades.Where(m => m.DataVencimento.Equals(mensalidade.DataVencimento)).FirstOrDefault();
            if (mensalidade1 == null)
                return 0;
            else
                return 1;
        }

        public override IEnumerable<Mensalidade> GetAll()
        {
            return context.Mensalidades.Include("Socio").ToList();
        }

        public virtual Mensalidade GetById(int id)
        {
            IEnumerable<Mensalidade> Mensalidades = context.Mensalidades.Include("Socio").ToList();
            Mensalidade Mensalidade = new Mensalidade();
            foreach (Mensalidade m in Mensalidades)
            {
                if (m.Id == id)
                    Mensalidade = m;
            }

            return Mensalidade;
        }

        public override int Delete(int id)
        {
            Mensalidade mensalidade = context.Mensalidades.Find(id);
            if (mensalidade != null)
            {
                if (mensalidade.Quitada == true)
                {
                    context.Mensalidades.Remove(mensalidade);
                    context.SaveChanges();
                    return 1;
                }
                else
                    return 0;
            }
            else
                return -1;
        }
    }
}
