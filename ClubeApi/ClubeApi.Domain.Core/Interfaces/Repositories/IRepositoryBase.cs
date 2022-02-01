namespace ClubeApi.Domain.Core.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        //Métodos a serem desenvolvidos para esta classe
        //Método para cadastrar objeto
        void Add(TEntity obj);

        //Método para atualizar objeto
        void Update(TEntity obj);

        //Método para deletar objeto
        void Delete(int id);

        //Método para listar objetos
        IEnumerable<TEntity> GetAll();

        //Método para selecionar objeto por ID
        TEntity GetById(int id);
    }
}
