namespace ClubeApi.Domain.Core.Interfaces.Services
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        //Métodos a serem desenvolvidos para esta classe(segue o padrão do repositório)
        int Add(TEntity obj);

        void Update(TEntity obj);

        int Delete(int id);

        IEnumerable<TEntity> GetAll();

        TEntity GetById(int id);
    }
}
