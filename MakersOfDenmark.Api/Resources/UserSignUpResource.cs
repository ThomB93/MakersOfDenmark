using MakersOfDenmark.Core.Models;

namespace MakersOfDenmark.Api.Resources
{
    public class UserSignUpResource
    {
        public string? Email { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Password { get; set; }
        public SaveAddressResource? Address { get; set; }
    }
}