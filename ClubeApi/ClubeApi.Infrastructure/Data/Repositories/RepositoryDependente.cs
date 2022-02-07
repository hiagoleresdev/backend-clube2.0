using ClubeApi.Domain.Core.Interfaces.Repositories;
using ClubeApi.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ClubeApi.Infrastructure.Data.Repositories
{
    public class RepositoryDependente : RepositoryBase<Dependente>, IRepositoryDependente
    {
        //Atributo de contexto para controle do banco
        private readonly SqlDbContext context;

        //Construtor
        public RepositoryDependente(SqlDbContext context) : base(context)
        {
            this.context = context;
        }

        public override int Verify(Dependente dependente)
        {
            Pessoa pessoa = context.Pessoas.Where(p => p.Nome.Equals(dependente.Nome)).FirstOrDefault();
            if(pessoa == null) 
                return 0;
            else
                return 1;
        }

        public override IEnumerable<Dependente> GetAll()
        {
            return context.Dependentes.Include("Socio").ToList();
        }

        public override Dependente GetById(int id)
        {
            IEnumerable<Dependente> dependentes = context.Dependentes.Include("Socio").ToList();
            Dependente dependente = new Dependente();
            foreach (Dependente d in dependentes)
            {
                if (d.Id == id)
                    dependente = d;
            }

            return dependente;
        }
    }
}
