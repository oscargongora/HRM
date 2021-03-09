using HRM.Core.Interfaces.Repositories;
using HRM.Infrastructure.Data;
using System.Threading.Tasks;

namespace HRM.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly HRMDbContext _context;

        public IRepository repository { get; private set; }

        public UnitOfWork(HRMDbContext context)
        {
            _context = context;
            repository = new Repository(context);
        }
        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
