using MakersOfDenmark.Core.Models.Auth;
using MakersOfDenmark.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MakersOfDenmark.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DbContext context) : base(context)
        {
        }
    }
}