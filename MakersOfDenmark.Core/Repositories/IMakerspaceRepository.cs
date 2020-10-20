using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using MakersOfDenmark.Core.Models.Makerspaces;

namespace MakersOfDenmark.Core.Repositories
{
    public interface IMakerspaceRepository
    {
        public IEnumerable<Makerspace> GetAllMakerspaces();
    }
}