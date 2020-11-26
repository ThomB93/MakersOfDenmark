using System;
using System.Collections.Generic;
using MakersOfDenmark.Core.Models.Auth;

namespace MakersOfDenmark.Core.Services
{
    public interface IAuthService
    {
        string GenerateJwt(User user, IList<string> roles);
    }
}