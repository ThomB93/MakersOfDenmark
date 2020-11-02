using System.Threading.Tasks;
using MakersOfDenmark.Core;
using MakersOfDenmark.Core.Models.Badges;
using MakersOfDenmark.Core.Services;

namespace MakersOfDenmark.Services
{
    public class BadgeService : IBadgeService
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public BadgeService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        
        public async Task<Badge> CreateBadge(Badge newBadge)
        {
            await _unitOfWork.Badges.AddAsync(newBadge);
            await _unitOfWork.CommitAsync();                    
            
            return newBadge;
        }
    }
}