using ClubeApi.Domain.Models;

namespace ClubeApi.Domain.Core.Interfaces.Repositories
{
    public interface IRepositoryMensalidade : IRepositoryBase<Mensalidade>
    {
        //Método para cadastrar mensalidades para sócio cadastrado em categoria determinada
        void AddSimultaneously(Socio socio);
    }
}
