using MakersOfDenmark.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
        
    }
}