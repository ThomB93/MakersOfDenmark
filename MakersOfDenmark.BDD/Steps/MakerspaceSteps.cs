using System;
using System.Threading.Tasks;
using FluentAssertions;
using MakersOfDenmark.Core;
using MakersOfDenmark.Core.Models.Makerspaces;
using MakersOfDenmark.Core.Repositories;
using MakersOfDenmark.Core.Services;
using MakersOfDenmark.Services;
using Moq;
using TechTalk.SpecFlow;

namespace MakersOfDenmark.BDD.Steps
{
    [Binding]
    public class MakerspaceSteps
    {
        public Makerspace DummyMakerspace;
        public MakerspaceService MakerspaceService;

        [Given(@"the makerspacename (.*)")]
        public void GivenTheMakerspacenameTest_Makerspace(string makerspaceName)
        {
            //arrange
            DummyMakerspace = new Makerspace { Id = 1, Name = makerspaceName};

            var mockMakerspaceRepository = new Mock<IMakerspaceRepository>();
            mockMakerspaceRepository.Setup(ms => ms.AddAsync(It.IsAny<Makerspace>()));
            mockMakerspaceRepository.Setup(ms => ms.GetMakerspaceWithOwnerById(It.IsAny<int>())).Returns(Task.FromResult<Makerspace>(DummyMakerspace));

            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(_ => _.Makerspaces).Returns(mockMakerspaceRepository.Object);

            MakerspaceService = new MakerspaceService(mockUnitOfWork.Object);

            
        }
        
        [Then(@"I want to create a makerspace")]
        public void ThenIWantToCreateAMakerspace()
        {
            //act
            var makerspaceSaved = MakerspaceService.CreateMakerspace(DummyMakerspace).Result;

            makerspaceSaved.Should().NotBeNull();
            makerspaceSaved.Should().Be(DummyMakerspace,
                "the makerspace that was saved should be returned by the service.");


            //mockMakerspaceRepository.Verify(_ => _.AddAsync(It.IsAny<Makerspace>()), Times.Once);
            //mockUnitOfWork.Verify(_ => _.CommitAsync(), Times.Once());
        }

        [Then(@"the name should be (.*)")]
        public async void ThenTheNameShouldBe(string name)
        {
            var result = await MakerspaceService.GetMakerspaceWithOwnerById(1);
            result.Should().Be(DummyMakerspace);
        }

    }
}
