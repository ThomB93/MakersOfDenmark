using System.Collections.Generic;
using System.Threading.Tasks;
using MakersOfDenmark.Core;
using MakersOfDenmark.Core.Models.Makerspaces;
using MakersOfDenmark.Core.Services;

namespace MakersOfDenmark.Services
{
    //Wraps the repository actions inside unit of work wrappers (transactions)
    public class MakerspaceService : IMakerspaceService
    {
        private readonly IUnitOfWork _unitOfWork;

        public MakerspaceService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public Task<IEnumerable<Makerspace>> GetAllMakerspacesWithOwner()
        {
            return _unitOfWork.Makerspaces.GetAllMakerspacesWithOwner();
        }

        public async Task<Makerspace> GetMakerspaceWithOwnerById(int id)
        {
            return await _unitOfWork.Makerspaces.GetMakerspaceWithOwnerById(id);
        }

        public async Task<Makerspace> CreateMakerspace(Makerspace newMakerspace)
        {
            await _unitOfWork.Makerspaces
                .AddAsync(newMakerspace);
            await _unitOfWork.CommitAsync();                    
            
            return newMakerspace;
        }

        public async Task<Makerspace> UpdateMakerspace(Makerspace makerspaceToBeUpdated, Makerspace makerspace)
        {
            makerspaceToBeUpdated.Name = makerspace.Name;
            makerspaceToBeUpdated.Access_Type = makerspace.Access_Type;
            makerspaceToBeUpdated.Logo_Url = makerspace.Logo_Url;
            makerspaceToBeUpdated.Space_Type = makerspace.Space_Type;
            makerspaceToBeUpdated.CVR = makerspace.CVR;
            //TODO: Add updates for new properties

            await _unitOfWork.CommitAsync();
            
            return makerspaceToBeUpdated;
        }

        public async Task<Makerspace> DeleteMakerspace(Makerspace makerspaceToBeDeleted)
        {
            _unitOfWork.Makerspaces.Remove(makerspaceToBeDeleted);

            await _unitOfWork.CommitAsync();

            return makerspaceToBeDeleted;
        }
    }
}