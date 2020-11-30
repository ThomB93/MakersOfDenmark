using System;
using System.Threading;
using AutoMapper;
using MakersOfDenmark.Api.Controllers;
using MakersOfDenmark.Api.Resources;
using MakersOfDenmark.Core.Models.Auth;
using MakersOfDenmark.Core.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace MakersOfDenmark.Tests
{
    public class AuthControllerTest
    {
        private readonly AuthController _controller;

        private readonly Guid _userGuid;

        public AuthControllerTest()
        {
            // Mocking all the shit
            var loggerMock = new Mock<ILogger<AuthController>>();
            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(x => x.Map<UserSignUpResource, User>(It.IsAny<UserSignUpResource>())).Returns(new User
            {
                UserName = "test@testesen.dk",
                Id = _userGuid,
                PasswordHash = "1234Abc!"
            });
            _userGuid = new Guid();
            var userStore = new Mock<IUserPasswordStore<User>>();
            userStore.Setup(x => x.FindByIdAsync(_userGuid.ToString(), CancellationToken.None))
                .ReturnsAsync(new User
                {
                    UserName = "test@testesen.dk",
                    Id = _userGuid,
                    PasswordHash = "1234Abc!"
                });

            //Mock<UserManager> userManagerMock = new Mock<UserManager>();

            var roleStore = new Mock<IRoleStore<Role>>();
            roleStore.Setup(x => x.FindByNameAsync("admin", CancellationToken.None))
                .ReturnsAsync(new Role
                {
                    Name = "admin"
                });
            var roleManagerMock = new Mock<RoleManager<Role>>();
            var userManagerMock = new Mock<UserManager<User>>();
            var authServiceMock = new Mock<IAuthService>();

            //produces an error
            _controller = new AuthController(loggerMock.Object, mapperMock.Object, userManagerMock.Object,
                roleManagerMock.Object, authServiceMock.Object);
        }

        [Fact]
        public async void UserShouldBeCreatedSuccessfullyFromUserResource()
        {
            // Arrange
            UserSignUpResource userSignUpResource = new UserSignUpResource
            {
                Email = "test@test.com",
                FirstName = "Thomas",
                LastName = "Test",
                Password = "1234Abc!"
            };

            // Act
            var result = await _controller.SignUp(userSignUpResource);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(_controller.Created(string.Empty, string.Empty), result);
        }
    }
}