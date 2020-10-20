using MakersOfDenmark.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using MakersOfDenmark.Core.Models.Auth;
using MakersOfDenmark.Core.Models.Makerspaces;
using MakersOfDenmark.Data.Repositories;
using Xunit;

namespace MakersOfDenmark.Tests.Repositories
{
    public class MakerspaceTests
    {
        [Fact]
        public void ShouldGetAll()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<MakersOfDenmarkDbContext>()
                .UseInMemoryDatabase(databaseName: "ShouldReturnAllMakerspaces").Options;

            using (var context = new MakersOfDenmarkDbContext(options))
            {
                context.Makerspaces.Add(new Makerspace {Id = 1});
                context.Makerspaces.Add(new Makerspace {Id = 2});
                context.Makerspaces.Add(new Makerspace {Id = 3});
                
                context.SaveChanges();
            }
            
            using (var context = new MakersOfDenmarkDbContext(options))
            {
                var repository = new MakerspaceRepository(context);

                // Act
                var makerspaces = repository.GetAllMakerspaces();

                // Assert
                Assert.Equal(3, makerspaces.Count());
                Assert.Contains(makerspaces, d => d.Id == 1);
                Assert.Contains(makerspaces, d => d.Id == 2);
                Assert.Contains(makerspaces, d => d.Id == 3);
                Assert.DoesNotContain(makerspaces, d => d.Id == 4);
            }
        }
        
        [Fact]
        public void ShouldSaveTheMakerspace()
        {
            //arrange
            var options = new DbContextOptionsBuilder<MakersOfDenmarkDbContext>()
                .UseInMemoryDatabase(databaseName: "ShouldSaveTheMakerspace").Options;

            var user = new User
            {
                FirstName = "Test",
                LastName = "Test"
            };
            
            var makerspace = new Makerspace
            {
                Id = 1, 
                Name = "Test",
                Space_Type = "Test",
                Access_Type = "Access",
                CVR = "12345678",
                Logo_Url = "public/test.png",
                Owner = user
            };

            using (var context = new MakersOfDenmarkDbContext(options))
            {
                // context.Users.Add(user);
                // context.SaveChanges();
            }
            
            //act
            using (var context = new MakersOfDenmarkDbContext(options))
            {
                var repository = new MakerspaceRepository(context);
                repository.Save(makerspace);
            }
            
            //assert

            using (var context = new MakersOfDenmarkDbContext(options))
            {
                var makerspaces = context.Makerspaces.ToList();
                var storedmakerspaces = Assert.Single(makerspaces);
                
                Assert.Equal(makerspace.Id, storedmakerspaces.Id);
                Assert.Equal(makerspace.Name, storedmakerspaces.Name);
                Assert.Equal(makerspace.Space_Type, storedmakerspaces.Space_Type);
                Assert.Equal(makerspace.Access_Type, storedmakerspaces.Access_Type);
                Assert.Equal(makerspace.CVR, storedmakerspaces.CVR);
                Assert.Equal(makerspace.Logo_Url, storedmakerspaces.Logo_Url);
                Assert.Equal(makerspace.Owner.FirstName, storedmakerspaces.Owner.FirstName);
                Assert.Equal(makerspace.Owner.LastName, storedmakerspaces.Owner.LastName);
                Assert.Equal(makerspace.Owner.Id, storedmakerspaces.Owner.Id);
                
            }
        }
        [Fact]
        public void ShouldUpdateMakerSpace()
        {
            //arrange
            var options = new DbContextOptionsBuilder<MakersOfDenmarkDbContext>()
                .UseInMemoryDatabase(databaseName: "ShouldSaveTheMakerspace").Options;
            
            var user = new User
            {
                FirstName = "Test",
                LastName = "Test"
            };
            
            var makerspace = new Makerspace
            {
                Id = 1, 
                Name = "Test",
                Space_Type = "Test",
                Access_Type = "Access",
                CVR = "12345678",
                Logo_Url = "public/test.png",
                Owner = user
            };
            
            
        }

    }
}