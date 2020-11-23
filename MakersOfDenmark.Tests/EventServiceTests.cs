using System;
using System.Collections.Generic;
using System.Text;
using MakersOfDenmark.Core.Models.Auth;
using Microsoft.AspNetCore.Identity;
using Moq;
using Xunit;

namespace MakersOfDenmark.Tests
{
    class EventTests
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

        //[Fact]
        //public void EventShouldBeCreated()
        //{
            
        //}
    }
}
