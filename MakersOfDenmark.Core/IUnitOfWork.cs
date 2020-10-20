using System;
using System.Threading.Tasks;

namespace MakersOfDenmark.Core
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> CommitAsync();
    }
}