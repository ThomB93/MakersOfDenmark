using System.Threading.Tasks;
using MakersOfDenmark.Core;
using MakersOfDenmark.Core.Repositories;
using MakersOfDenmark.Core.Services;
using MakersOfDenmark.Data.Repositories;

namespace MakersOfDenmark.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MakersOfDenmarkDbContext _context;
        private MakerspaceRepository Makerspaces { get; set; }
        
        public UnitOfWork(MakersOfDenmarkDbContext context)
        {
            this._context = context;
            this.Makerspaces = new MakerspaceRepository(context);
        }


        IMakerspaceRepository IUnitOfWork.Makerspaces
        {
            get => Makerspaces;
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