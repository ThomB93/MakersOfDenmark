using System.Collections.Generic;
using MakersOfDenmark.Core.Models.Auth;

namespace MakersOfDenmark.Services
{
    public interface IAuthService
    {
        string GenerateJwt(User user, IList<string> roles);

    }
}