using System;

namespace MakersOfDenmark.Services
{
    public class AuthService
    {
        private readonly JwtSettings _jwtSettings;

        public AuthService(IOperationSnapshot<JwtSettings> jwtSettings)
        {
            _jwtSettings = jwtSettings.Value;
        }
    }
}
