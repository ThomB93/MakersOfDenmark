using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using MakersOfDenmark.Core.Models.Makerspaces;

namespace MakersOfDenmark.Core.Repositories
{
    public interface IMakerspaceRepository : IRepository<Makerspace>
    {
        public IEnumerable<Makerspace> GetAllMakerspaces();
        public void Save(Makerspace makerspace);
        public void Update(Makerspace makerspace);
        public Makerspace GetMakerspaceById(int id);

        public void Delete(int Id);
    }
}