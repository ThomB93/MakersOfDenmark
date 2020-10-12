using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;
using MakersOfDenmark.Services;
using MakersOfDenmark.Services.Settings;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MakersOfDenmark.Core.Models.Auth;
using System.Collections.Generic;
using System.Threading;
using MakersOfDenmark.Api.Resources;
using MakersOfDenmark.Api.Controllers;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

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
            
            _userGuid = new Guid();
            var userStore = new Mock<IUserStore<User>>();
            userStore.Setup(x => x.FindByIdAsync(_userGuid.ToString(), CancellationToken.None))
                .ReturnsAsync(new User()
                {
                    UserName = "test@testesen.dk",
                    Id = _userGuid
                });
            
            var userManagerMock = new UserManager<User>(userStore.Object,null, null, null, null, null, null, null, null);
            
            var roleStore = new Mock<IRoleStore<Role>>();
            roleStore.Setup(x => x.FindByNameAsync("admin", CancellationToken.None))
            .ReturnsAsync(new Role(){
                Name = "admin"
            });
            var roleManagerMock = new RoleManager<Role>(roleStore.Object, null, null, null, null);
            
            var authServiceMock = new Mock<AuthService>();

            _controller = new AuthController(loggerMock.Object, mapperMock.Object, userManagerMock, roleManagerMock, authServiceMock.Object);
        }

        [Fact]
        public async void UserCreatedSuccessfully()
        {
            // Arrange
            UserSignUpResource userSignUpResource = new UserSignUpResource {
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