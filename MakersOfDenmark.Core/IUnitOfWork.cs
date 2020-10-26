using System;
using System.Threading.Tasks;
using MakersOfDenmark.Core.Repositories;
using MakersOfDenmark.Core.Services;

namespace MakersOfDenmark.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IMakerspaceRepository Makerspaces { get; }
        Task<int> CommitAsync();
    }
}