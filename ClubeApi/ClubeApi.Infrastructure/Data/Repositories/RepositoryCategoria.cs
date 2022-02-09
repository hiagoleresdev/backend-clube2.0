using ClubeApi.Domain.Core.Interfaces.Repositories;
using ClubeApi.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ClubeApi.Infrastructure.Data.Repositories
{
    public class RepositoryCategoria : RepositoryBase<Categoria>, IRepositoryCategoria
    {
        //Atributo de contexto para controle do banco
        private readonly SqlDbContext context;

        //Construtor
        public RepositoryCategoria(SqlDbContext context) : base(context)
        {
            this.context = context;
        }

        public override int Verify(Categoria categoria)
        {
            Categoria categoria1 = context.Categorias.Where(c => c.Tipo.Equals(categoria.Tipo)).FirstOrDefault();
            if (categoria1 == null)
                return 0;
            else
                return 1;
        }

        public override int Delete(int id)
        {
            int x = 0;
            IEnumerable<Socio> socios = context.Socios.Include("Categoria").ToList();
            foreach (Socio socio in socios)
            {
                if (socio.Categoria.Id == id)
                    x++;
            }
            if (x == 0)
            {
                Categoria categoria = context.Categorias.Find(id);
                if(categoria != null)
                {
                    context.Categorias.Remove(categoria);
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
