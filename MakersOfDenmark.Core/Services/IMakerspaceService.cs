﻿using System.Collections.Generic;
using System.Threading.Tasks;
using MakersOfDenmark.Core.Models.Makerspaces;

namespace MakersOfDenmark.Core.Services
{
    public interface IMakerspaceService
    {
        Task<IEnumerable<Makerspace>> GetAllMakerspaces();
        Task<Makerspace> GetMakerspaceById(int id);
        Task<Makerspace> CreateMakerspace(Makerspace newMakerspace);
        Task UpdateMakerspace(Makerspace makerspaceToBeUpdated, Makerspace makerspace);
        Task DeleteMakerspace(Makerspace makerspace);
    }
}