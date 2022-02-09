﻿using ClubeApi.Domain.Models;

namespace ClubeApi.Domain.Core.Interfaces.Services
{
    public interface IServiceMensalidade : IServiceBase<Mensalidade>
    {
        void AddSimultaneously(Socio socio);
    }
}
