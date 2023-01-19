namespace CrudSample.Domain.Repositorys.UoW
{
    public interface IUnityOfWork
    {
        Task CommitAsync();
    }
}
