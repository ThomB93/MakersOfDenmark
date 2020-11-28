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

namespace MakersOfDenmark.Tests
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

        private readonly List<User> _users;
        private readonly Guid _userId;

        public BadgeTests()
        {
            _userId = new Guid();
            _users = new List<User>
            {
                new User {Id = _userId, FirstName = "Mads", LastName = "Test", UserBadges = new List<UserBadge>()}
            };
        }

        [Fact]
        public async void ServiceShouldAddBadgeToUser()
        {
            var badgeToAdd = new Badge
            {
                Id = 1,
                Name = "Test",
                Description = "Test"
            };

            Guid guid = new Guid();

            var badgeRepositoryMock = new Mock<IBadgeRepository>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            var userManagerMock = MockUserManager<User>();
            userManagerMock.Setup(um => um.Users).Returns(_users.AsQueryable);

            BadgeService badgeService = new BadgeService(mockUnitOfWork.Object, userManagerMock.Object);

            //Act
            var badgeAdded = badgeService.AddBadgeToUser(_userId, badgeToAdd);

            //Assert
            badgeAdded.Should().Equals(badgeToAdd);
        }
    }
}
