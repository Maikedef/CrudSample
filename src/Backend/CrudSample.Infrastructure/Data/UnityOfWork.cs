using CrudSample.Domain.Repositories.UoW;

namespace CrudSample.Infrastructure.Data
{
    public class UnityOfWork : IDisposable, IUnityOfWork
    {
        private readonly CrudSampleDbContext _context;
        private bool _disposed;

        public UnityOfWork(CrudSampleDbContext context)
        {
            _context = context;
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
        }

        private void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                _context.Dispose();
            }
            _disposed = true;
        }
    }
}
