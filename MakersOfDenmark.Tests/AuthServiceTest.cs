using MakersOfDenmark.Services;
using MakersOfDenmark.Services.Settings;
using Microsoft.Extensions.Options;

namespace MakersOfDenmark.Tests
{
    public class AuthServiceTest
    {
        private readonly AuthService _authservice;


        public AuthServiceTest(IOptionsSnapshot<JwtSettings> settings)
        {
            _authservice = new AuthService(settings);
        }

        // [Fact]
        // public async Task GeneratedJwtIsValid()
        // {
        //     // Input code to create unit-test here
        //     var testUser = new User{
        //         FirstName = "Test",
        //         LastName = "Testesen",
        //         Id = new Guid(),
        //         UserName = "Test@testesen.dk",
        //         Email = "Test@testesen.dk"
        //     };

        //     List<string> roles = new List<string>();

        //     var result = _authservice.GenerateJwt(testUser, roles);

        //     // Compare returned token with expected value

        // }
    }
}