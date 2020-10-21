using System.Threading.Tasks;
using MakersOfDenmark.Core;
using MakersOfDenmark.Core.Repositories;
using MakersOfDenmark.Data.Repositories;

namespace MakersOfDenmark.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MakersOfDenmarkDbContext _context;
        
        private MakerspaceRepository _makerspaceRepository;
        public UnitOfWork(MakersOfDenmarkDbContext context)
        {
            this._context = context;
        }
        //if null, create new makerspace repository, if not, use existing
        public IMakerspaceRepository Makerspaces => _makerspaceRepository ??= new MakerspaceRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}