namespace ClubeApi.Domain.Core.Interfaces.Services
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        //Métodos a serem desenvolvidos para esta classe(segue o padrão do repositório)
        void Add(TEntity obj);

        void Update(TEntity obj);

        void Delete(int id);

        IEnumerable<TEntity> GetAll();

        TEntity GetById(int id);
    }
}
