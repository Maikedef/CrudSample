namespace CrudSample.Domain.Repositories.UoW
{
    public interface IUnityOfWork
    {
        Task CommitAsync();
    }
}
