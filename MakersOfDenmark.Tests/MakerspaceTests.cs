using MakersOfDenmark.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using FluentAssertions.Execution;
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

namespace MakersOfDenmark.Tests
{
    public class MakerspaceTests
    {
        [Fact]
        public async void ServiceShouldGetAllMakerspaces()
        {
            // Arrange
            List<Makerspace> dummydata = new List<Makerspace>()
            {
                new Makerspace() {Id = 1},
                new Makerspace() {Id = 2},
                new Makerspace() {Id = 3}
            };

            var mockMakerspaceRepository = new Mock<IMakerspaceRepository>();
            mockMakerspaceRepository.Setup(mr => mr.GetAllMakerspacesWithOwner())
                .ReturnsAsync(dummydata);

            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(_ => _.Makerspaces).Returns(mockMakerspaceRepository.Object);

            MakerspaceService makerspaceService = new MakerspaceService(mockUnitOfWork.Object);

            // Act
            var makerspaces = await makerspaceService.GetAllMakerspacesWithOwner();

            // Assert
            using (new AssertionScope())
            {
                makerspaces.Should().HaveCount(3);
                makerspaces.Should().OnlyHaveUniqueItems(m => m.Id);
                makerspaces.Should().ContainItemsAssignableTo<Makerspace>();
                makerspaces.Should().NotContainNulls();
                makerspaces.Should().Contain(m => m.Id == 1)
                    .And.Contain(m => m.Id == 2)
                    .And.Contain(m => m.Id == 3);
            }
        }
        [Fact]
        public void ServiceShouldGetMakerspaceById()
        {
            Guid guid = new Guid();
            Makerspace makerspaceToFind = new Makerspace()
            {
                Id = 1,
                OwnerId = guid,
            };
            
            var mockMakerspaceRepository = new Mock<IMakerspaceRepository>();
            
            mockMakerspaceRepository.Setup(ms => ms.GetMakerspaceWithOwnerById(It.IsAny<int>()))
                .ReturnsAsync(makerspaceToFind);
            
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(_ => _.Makerspaces).Returns(mockMakerspaceRepository.Object);
            
            MakerspaceService makerspaceService = new MakerspaceService(mockUnitOfWork.Object);

            var makerspaceFoundById = makerspaceService.GetMakerspaceWithOwnerById(1).Result;

            makerspaceFoundById.Should().NotBeNull();
            makerspaceFoundById.Should().Be(makerspaceToFind);
        }

        [Fact]
        public void ServiceShouldSaveNewMakerspace()
        {
            //arrange
            Makerspace dummyMakerspace = new Makerspace {Id = 1};

            var mockMakerspaceRepository = new Mock<IMakerspaceRepository>();
            mockMakerspaceRepository.Setup(ms => ms.AddAsync(It.IsAny<Makerspace>()));
            
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(_ => _.Makerspaces).Returns(mockMakerspaceRepository.Object);
            
            MakerspaceService makerspaceService = new MakerspaceService(mockUnitOfWork.Object);

            //act
            var makerspaceSaved = makerspaceService.CreateMakerspace(dummyMakerspace).Result;
            
            makerspaceSaved.Should().NotBeNull();
            makerspaceSaved.Should().Be(dummyMakerspace, because: "the makerspace that was saved should be returned by the service.");
            
            mockMakerspaceRepository.Verify(_ => _.AddAsync(It.IsAny<Makerspace>()), Times.Once);
            mockUnitOfWork.Verify(_ => _.CommitAsync(), Times.Once());
        }

        [Fact]
        public void ServiceShouldUpdateMakerSpace()
        {
            //arrange
            var mockMakerspaceRepository = new Mock<IMakerspaceRepository>();
            
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(_ => _.Makerspaces).Returns(mockMakerspaceRepository.Object);
            
            MakerspaceService makerspaceService = new MakerspaceService(mockUnitOfWork.Object);

            Makerspace makerspaceToBeUpdated = new Makerspace()
            {
                Id = 1,
                Name = "Test",
                Access_Type = "Public",
                Logo_Url = "image.png",
                Space_Type = "lasers",
                CVR = "12345678"
                //TODO: Add new properties to test
            };

            Makerspace newMakerspace = new Makerspace()
            {
                Id = 1,
                Name = "Test two",
                Access_Type = "Private",
                Logo_Url = "image.jpg",
                Space_Type = "more lasers",
                CVR = "87654321"
            };
            
            //act
            var updatedMakerspace = makerspaceService.UpdateMakerspace(makerspaceToBeUpdated, newMakerspace).Result;
            
            //assert
            updatedMakerspace.Should().NotBeNull();
            updatedMakerspace.Should().BeEquivalentTo(newMakerspace, because: "the updated makerspace should contain the changed property values.");
            
            mockUnitOfWork.Verify(_ => _.CommitAsync(), Times.Once);
        }

        [Fact]
        public void ServiceShouldDeleteMakerspace()
        {
            //arrange
            var mockMakerspaceRepository = new Mock<IMakerspaceRepository>();
            mockMakerspaceRepository.Setup(ms => ms.Remove(It.IsAny<Makerspace>()));
            
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(_ => _.Makerspaces).Returns(mockMakerspaceRepository.Object);
            
            MakerspaceService makerspaceService = new MakerspaceService(mockUnitOfWork.Object);

            var makerspaceToDelete = new Makerspace {Id = 1};
            
            //act
            var deletedMakerspace = makerspaceService.DeleteMakerspace(makerspaceToDelete).Result;

            //assert
            deletedMakerspace.Should().NotBeNull();
            deletedMakerspace.Should().Be(makerspaceToDelete);
            
            mockMakerspaceRepository.Verify(_ => _.Remove(It.IsAny<Makerspace>()), Times.Once);
            mockUnitOfWork.Verify(_ => _.CommitAsync(), Times.Once);
        }
    }
}