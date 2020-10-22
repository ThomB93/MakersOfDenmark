using MakersOfDenmark.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using MakersOfDenmark.Core;
using MakersOfDenmark.Core.Models.Auth;
using MakersOfDenmark.Core.Models.Makerspaces;
using MakersOfDenmark.Core.Repositories;
using MakersOfDenmark.Core.Services;
using MakersOfDenmark.Data.Repositories;
using MakersOfDenmark.Services;
using Moq;
using Newtonsoft.Json;
using Xunit;

namespace MakersOfDenmark.Tests.Repositories
{
    public class MakerspaceTests
    {

        
        //private IMakerspaceService _makerspaceService;

        public MakerspaceTests()
        {
            
        }
        
        [Fact]
        public async void ShouldGetAll()
        {
            // Arrange
            
            List<Makerspace> dummydata = new List<Makerspace>()
            {
                new Makerspace() { Id = 1, OwnerId = new Guid()},
                new Makerspace() { Id = 2, OwnerId = new Guid()},
                new Makerspace() { Id = 3, OwnerId = new Guid()}
            };
            var mockMakerspaceRepository = new Mock<IMakerspaceRepository>();
            mockMakerspaceRepository.Setup(ms => ms.GetAllMakerspacesWithOwner())
                .ReturnsAsync(dummydata);
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(_ => _.Makerspaces).
                Returns(mockMakerspaceRepository.Object);
            MakerspaceService makerspaceService = new MakerspaceService(mockUnitOfWork.Object);
                

                // Act
                var makerspaces = await makerspaceService.GetAllMakerspacesWithOwner();

                // Assert
                Assert.Equal(3, makerspaces.Count());
                Assert.Contains(makerspaces, d => d.Id == 1);
                Assert.Contains(makerspaces, d => d.Id == 2);
                Assert.Contains(makerspaces, d => d.Id == 3);
                Assert.DoesNotContain(makerspaces, d => d.Id == 4);
            
        }
        
        [Fact]
        public void ShouldSaveTheMakerspace()
        {
            Makerspace DummyMakerspace = new Makerspace();
            
            var mockMakerspaceRepository = new Mock<IMakerspaceRepository>();
            mockMakerspaceRepository.Setup(ms => ms.AddAsync(It.IsAny<Makerspace>()));
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(_ => _.Makerspaces).
                Returns(mockMakerspaceRepository.Object);
            MakerspaceService makerspaceService = new MakerspaceService(mockUnitOfWork.Object);

            //act
            makerspaceService.CreateMakerspace(DummyMakerspace);
            
            mockMakerspaceRepository.Verify(_ => _.AddAsync(It.IsAny<Makerspace>()), Times.Once);
        }
        [Fact]
        public void ShouldUpdateMakerSpace()
        {
            var mockMakerspaceRepository = new Mock<IMakerspaceRepository>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(_ => _.Makerspaces).
                Returns(mockMakerspaceRepository.Object);
            MakerspaceService makerspaceService = new MakerspaceService(mockUnitOfWork.Object);
            
            Makerspace ToBeUpdated = new Makerspace()
            {
                Name = "Test",
                Access_Type = "Public",
                Logo_Url = "html",
                Space_Type = "laser cutter",
                CVR = "12345678"
            };

            Makerspace newMakerspace = new Makerspace()
            {
                Name = "123",
                Access_Type = "private",
                Logo_Url = "test",
                Space_Type = "Changed",
                CVR = "87654321"
            };

            makerspaceService.UpdateMakerspace(ToBeUpdated, newMakerspace);
            
            mockUnitOfWork.Verify(_ => _.CommitAsync(), Times.Once);

        }

        [Fact]
        public void DeleteMakerspace()
        {
            //arrange
            
            var mockMakerspaceRepository = new Mock<IMakerspaceRepository>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            
            mockMakerspaceRepository.Setup(ms => ms.Remove(It.IsAny<Makerspace>()));
            mockUnitOfWork.Setup(_ => _.Makerspaces).
                Returns(mockMakerspaceRepository.Object);
            MakerspaceService makerspaceService = new MakerspaceService(mockUnitOfWork.Object);

            makerspaceService.DeleteMakerspace(new Makerspace());
            
            mockUnitOfWork.Verify(_ => _.CommitAsync(), Times.Once);
            mockMakerspaceRepository.Verify(_ => _.Remove(It.IsAny<Makerspace>()),Times.Once);



        }

        [Fact]
        public async void GetMakerspaceById()
        {
            var mockMakerspaceRepository = new Mock<IMakerspaceRepository>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            Guid guid = new Guid();
            Makerspace mks = new Makerspace()
            {
                Id = 1, 
                OwnerId = guid,
                
            };
            
            mockMakerspaceRepository.Setup(ms => ms.GetMakerspaceWithOwnerById(It.IsAny<int>()))
                .ReturnsAsync(mks);
            mockUnitOfWork.Setup(_ => _.Makerspaces).
                Returns(mockMakerspaceRepository.Object);
            MakerspaceService makerspaceService = new MakerspaceService(mockUnitOfWork.Object);

            var res = await makerspaceService.GetMakerspaceWithOwnerById(1);
            
            Assert.Equal(mks, res);
        }

    }
}