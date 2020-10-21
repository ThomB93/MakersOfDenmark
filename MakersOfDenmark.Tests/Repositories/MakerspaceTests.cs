using MakersOfDenmark.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using MakersOfDenmark.Core.Models.Auth;
using MakersOfDenmark.Core.Models.Makerspaces;
using MakersOfDenmark.Data.Repositories;
using Newtonsoft.Json;
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
                UserFK = user.Id
            };

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
                Assert.Equal(makerspace.UserFK, storedmakerspaces.UserFK);
                
                
            }
        }
        [Fact]
        public void ShouldUpdateMakerSpace()
        {
            //arrange
            var options = new DbContextOptionsBuilder<MakersOfDenmarkDbContext>()
                .UseInMemoryDatabase(databaseName: "ShouldUpdateTheMakerspace").Options;
            
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
                Access_Type = "Public",
                CVR = "12345678",
                Logo_Url = "public/test.png",
                UserFK = user.Id
            };
            
            using (var context = new MakersOfDenmarkDbContext(options))
            {
                var repository = new MakerspaceRepository(context);
                repository.Save(makerspace);
            }
            //act
            makerspace.Name = "test 2";
            makerspace.Space_Type = "Test 2";
            makerspace.Access_Type = "Private";
            makerspace.CVR = "87654321";
            makerspace.Logo_Url = "public/tree.png";
            
            using (var context = new MakersOfDenmarkDbContext(options))
            {
                var repository = new MakerspaceRepository(context);
                repository.Update(makerspace);
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
                Assert.Equal(makerspace.UserFK, storedmakerspaces.UserFK);
            }
        }

        [Fact]
        public void DeleteMakerspace()
        {
            //arrange
            var options = new DbContextOptionsBuilder<MakersOfDenmarkDbContext>()
                .UseInMemoryDatabase(databaseName: "ShouldDeleteTheMakerspace").Options;
            
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
                Access_Type = "Public",
                CVR = "12345678",
                Logo_Url = "public/test.png",
                UserFK = user.Id
            };
            
            using (var context = new MakersOfDenmarkDbContext(options))
            {
                var repository = new MakerspaceRepository(context);
                repository.Save(makerspace);
            }
            
            //act
            using (var context = new MakersOfDenmarkDbContext(options))
            {
                var repository = new MakerspaceRepository(context);
                repository.Delete(makerspace.Id);
            }
            
            //Assert
            using (var context = new MakersOfDenmarkDbContext(options))
            {
                var makerspaces = context.Makerspaces.ToList();
                Assert.Empty(makerspaces);
            }
        }

        [Fact]
        public void GetMakerspaceById()
        {
            var options = new DbContextOptionsBuilder<MakersOfDenmarkDbContext>()
                .UseInMemoryDatabase(databaseName: "ShouldGetMakerspaceById").Options;
            
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
                Access_Type = "Public",
                CVR = "12345678",
                Logo_Url = "public/test.png",
                UserFK = user.Id
            };
            
            using (var context = new MakersOfDenmarkDbContext(options))
            {
                var repository = new MakerspaceRepository(context);
                repository.Save(makerspace);
            }
            
            //act 

            var dbcontext = new MakersOfDenmarkDbContext(options);
            
            var makerspacerepository = new MakerspaceRepository(dbcontext);
            Makerspace storedMakerspace = makerspacerepository.FindById(makerspace.Id);
            //assert
            string makerspaceOutput = JsonConvert.SerializeObject(makerspace);
            string storedMakerspaceOutput = JsonConvert.SerializeObject(storedMakerspace);
            
            Assert.Equal(makerspaceOutput, storedMakerspaceOutput);

        }

    }
}