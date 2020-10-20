using System.Collections.Generic;
using System.Threading.Tasks;
using MakersOfDenmark.Core;
using MakersOfDenmark.Core.Models.Makerspaces;
using MakersOfDenmark.Core.Services;

namespace MakersOfDenmark.Services
{
    public class MakerspaceService : IMakerspaceService
    {
        private readonly IUnitOfWork _unitOfWork;

        public MakerspaceService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public Task<IEnumerable<Makerspace>> GetAllMakerspaces()
        {
            throw new System.NotImplementedException();
        }

        public Task<Makerspace> GetMakerspaceById(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Makerspace> CreateMakerspace(Makerspace newMakerspace)
        {
            await _unitOfWork.Makerspaces
                .AddAsync(newMakerspace);
            await _unitOfWork.CommitAsync();                    
            
            return newMakerspace;
        }

        public Task UpdateMakerspace(Makerspace makerspaceToBeUpdated, Makerspace makerspace)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteMakerspace(Makerspace makerspace)
        {
            throw new System.NotImplementedException();
        }
    }
}