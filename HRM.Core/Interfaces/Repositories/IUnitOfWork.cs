using System;
using System.Threading.Tasks;

namespace HRM.Core.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository repository { get; }
        Task<int> SaveChanges();
    }
}
