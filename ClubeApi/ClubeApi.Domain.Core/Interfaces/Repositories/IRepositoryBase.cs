namespace ClubeApi.Domain.Core.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        //Métodos a serem desenvolvidos para esta classe
        //Método para verificar cadastro repetido
        int Verify(TEntity entity);

        //Método para cadastrar objeto
        int Add(TEntity obj);

        //Método para atualizar objeto
        void Update(TEntity obj);

        //Método para deletar objeto
        int Delete(int id);

        //Método para listar objetos
        IEnumerable<TEntity> GetAll();

        //Método para selecionar objeto por ID
        TEntity GetById(int id);
    }
}
