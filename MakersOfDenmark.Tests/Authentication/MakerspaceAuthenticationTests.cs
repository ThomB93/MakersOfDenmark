using System;
using System.Linq;
using MakersOfDenmark.Core.Models.Auth;
using MakersOfDenmark.Core.Models.Makerspaces;
using MakersOfDenmark.Data;
using MakersOfDenmark.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace MakersOfDenmark.Tests.Authentication
{
    public class MakerspaceAuthenticationTests
    {
        [Fact]
        public void CorrectUserIsAddedAsOwnerWhenCreatingNewMakerspace()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<MakersOfDenmarkDbContext>()
                .UseInMemoryDatabase(databaseName: "ShouldAddCorrectUserAsOwnerToMakerspace").Options;
            
            var owner = new User
            {
                FirstName = "Owner",
                LastName = "Test"
            };
            
            using (var context = new MakersOfDenmarkDbContext(options))
            {
                context.Users.Add(owner);
                context.Makerspaces.Add(new Makerspace {Id = 1, UserFK = owner.Id});
                context.SaveChanges();
            }

            using (var context = new MakersOfDenmarkDbContext(options))
            {
                var repository = new MakerspaceRepository(context);

                var makerspaceAdded = repository.GetMakerspaceById(1);
                Assert.Equal(makerspaceAdded.UserFK, owner.Id);
            }

        }
    }
}