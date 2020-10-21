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
            return _unitOfWork.Makerspaces.GetAllAsync();
        }

        public async Task<Makerspace> GetMakerspaceById(int id)
        {
            return await _unitOfWork.Makerspaces.GetByIdAsync(id);
        }

        public async Task<Makerspace> CreateMakerspace(Makerspace newMakerspace)
        {
            await _unitOfWork.Makerspaces
                .AddAsync(newMakerspace);
            await _unitOfWork.CommitAsync();                    
            
            return newMakerspace;
        }

        public async Task UpdateMakerspace(Makerspace makerspaceToBeUpdated, Makerspace makerspace)
        {
            makerspaceToBeUpdated.Name = makerspace.Name;
            makerspaceToBeUpdated.Access_Type = makerspace.Access_Type;
            makerspaceToBeUpdated.Logo_Url = makerspace.Logo_Url;
            makerspaceToBeUpdated.Space_Type = makerspace.Space_Type;
            makerspaceToBeUpdated.CVR = makerspace.CVR;

            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteMakerspace(Makerspace makerspaceToBeDeleted)
        {
            _unitOfWork.Makerspaces.Remove(makerspaceToBeDeleted);

            await _unitOfWork.CommitAsync();
        }
    }
}