using Xunit;
using CarWorkshopMVC.Application.ApplicationUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Moq;
using System.Security.Claims;
using FluentAssertions;

namespace CarWorkshopMVC.Application.ApplicationUser.Tests
{
    public class UserContextTests
    {
        [Fact()]
        public void GetCurrentUser_withAuthenticateUser_ShouldReturnCurrentUser()
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier,"1"),
                new Claim(ClaimTypes.Email, "test@test.com"),
                new Claim(ClaimTypes.Role,"Admin"),
                new Claim(ClaimTypes.Role,"User")
            };

            var user = new ClaimsPrincipal(new ClaimsIdentity(claims,"Test"));
            var httpContextAccessorMock = new Mock<IHttpContextAccessor>();
            httpContextAccessorMock.Setup(x => x.HttpContext).Returns(new DefaultHttpContext()
            {
                User = user
            });
            var userContext = new UserContext(httpContextAccessorMock.Object);

            //act
            var currenUser = userContext.GetCurrentUser();

            //arrange
            currenUser.Should().NotBeNull();
            currenUser!.Id.Should().Be("1");
            currenUser.Email.Should().Be("test@test.com");
            currenUser.Roles.Should().ContainInOrder("Admin", "User");
        }
    }
}