using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using FluentAssertions;
using MakersOfDenmark.Core;
using MakersOfDenmark.Core.Models.Auth;
using MakersOfDenmark.Core.Models.Badges;
using MakersOfDenmark.Core.Models.UserRelations;
using MakersOfDenmark.Core.Repositories;
using MakersOfDenmark.Services;
using Microsoft.AspNetCore.Identity;
using Moq;
using Xunit;

namespace MakersOfDenmark.Tests.Repositories
{
    public class BadgeTests
    {
        public static Mock<UserManager<TUser>> MockUserManager<TUser>() where TUser : class
        {
            var store = new Mock<IUserStore<TUser>>();
            var mgr = new Mock<UserManager<TUser>>(store.Object, null, null, null, null, null, null, null, null);
            mgr.Object.UserValidators.Add(new UserValidator<TUser>());
            mgr.Object.PasswordValidators.Add(new PasswordValidator<TUser>());
            return mgr;
        }

        private List<User> _users;
        private Guid _userId;
        private Badge testBadge;

        public BadgeTests()
        {
            _userId = new Guid();
            _users = new List<User>
            {
                new User {Id = _userId, FirstName = "Mads", LastName = "Test", UserBadges = new List<UserBadge>()}
            };
            
            testBadge = new Badge
            {
                Id = 1,
                Name = "Test",
                Description = "Test"
            };
        }

        [Fact]
        public async void ServiceShouldAddBadgeToUser()
        {
            Guid guid = new Guid();

            var badgeRepositoryMock = new Mock<IBadgeRepository>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            var userManagerMock = MockUserManager<User>();
            userManagerMock.Setup(um => um.Users).Returns(_users.AsQueryable);

            BadgeService badgeService = new BadgeService(mockUnitOfWork.Object, userManagerMock.Object);

            //Act
            var badgeAdded = badgeService.AddBadgeToUser(_userId, testBadge);

            //Assert
            badgeAdded.Should().Equals(testBadge);
        }

        [Fact]
        public async void ServiceShouldRemoveBadgeFromUser()
        {
            //arrange
            var badgeRepositoryMock = new Mock<IBadgeRepository>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            
            var userManagerMock = MockUserManager<User>();
            userManagerMock.Setup(um => um.Users).Returns(_users.AsQueryable);
            
            BadgeService badgeService = new BadgeService(mockUnitOfWork.Object, userManagerMock.Object);
            
            var badgeToRemove = badgeService.AddBadgeToUser(_userId, testBadge);
            //act
            var isRemoved = badgeService.RemoveBadgeFromUser(_userId, badgeToRemove);
            //assert
            isRemoved.Should().BeTrue();
        }

        [Fact]
        public async void ServiceShouldSaveNewBadge()
        {
            //arrange
            Badge dummyBadge = new Badge {Id = 1};

            var mockBadgeRepository = new Mock<IBadgeRepository>();
            mockBadgeRepository.Setup(ms => ms.AddAsync(It.IsAny<Badge>()));
            
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(_ => _.Badges).Returns(mockBadgeRepository.Object);
            
            var userManagerMock = MockUserManager<User>();
            userManagerMock.Setup(um => um.Users).Returns(_users.AsQueryable);
            
            BadgeService BadgeService = new BadgeService(mockUnitOfWork.Object, userManagerMock.Object);

            //act
            var BadgeSaved = BadgeService.CreateBadge(dummyBadge).Result;
            
            BadgeSaved.Should().NotBeNull();
            BadgeSaved.Should().Be(dummyBadge, because: "the Badge that was saved should be returned by the service.");
            
            mockBadgeRepository.Verify(_ => _.AddAsync(It.IsAny<Badge>()), Times.Once);
            mockUnitOfWork.Verify(_ => _.CommitAsync(), Times.Once());
        }
    }
}
