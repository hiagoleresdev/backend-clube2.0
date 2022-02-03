﻿using ClubeApi.Domain.Core.Interfaces.Repositories;
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
    }
}
