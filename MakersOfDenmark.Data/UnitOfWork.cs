using System.Threading.Tasks;
using MakersOfDenmark.Core;

namespace MakersOfDenmark.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MakersOfDenmarkDbContext _context;
        public UnitOfWork(MakersOfDenmarkDbContext context)
        {
            this._context = context;
        }
        
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