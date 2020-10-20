using System;
using System.Threading.Tasks;
using MakersOfDenmark.Core.Repositories;

namespace MakersOfDenmark.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IMakerspaceRepository Makerspaces { get; }
        Task<int> CommitAsync();
    }
}