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

        public void AddSimultaneously(Socio socio)
        {
            for (int i = 1; i <= socio.Categoria.Meses; i++)
            {
                Mensalidade mensalidade = new Mensalidade();
                mensalidade.Socio = socio;
                mensalidade.ValorInicial = 298.20;
                mensalidade.Juros = 8;
                mensalidade.DataVencimento = this.DefinirVencimento(i);
                mensalidade.Quitada = false;

                context.Set<Mensalidade>().Add(mensalidade);
                context.SaveChanges();
            }
        }

        //Método para definir a data de vencimento 
        public DateTime DefinirVencimento(int mes)
        {
            DateTime data_atual = DateTime.Today;
            DateTime data_venc = data_atual.AddMonths(mes);
            String data_venc_s = data_venc.ToString("dd/MM/yyyy");
            data_venc = DateTime.ParseExact(data_venc_s, "d", null);
            return data_venc;
        }
    }
}
