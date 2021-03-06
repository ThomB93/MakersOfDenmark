﻿using System.Collections.Generic;
using System.Threading.Tasks;
using MakersOfDenmark.Core.Models.Makerspaces;

namespace MakersOfDenmark.Core.Services
{
    public interface IMakerspaceService
    {
        Task<IEnumerable<Makerspace>> GetAllMakerspacesWithOwner();
        Task<Makerspace> GetMakerspaceWithOwnerById(int id);
        Task<Makerspace> CreateMakerspace(Makerspace newMakerspace);
        Task<Makerspace> UpdateMakerspace(Makerspace makerspaceToBeUpdated, Makerspace makerspace);
        Task<Makerspace> DeleteMakerspace(Makerspace makerspace);
    }
}