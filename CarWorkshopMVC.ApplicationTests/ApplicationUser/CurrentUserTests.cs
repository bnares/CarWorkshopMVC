using Xunit;
using CarWorkshopMVC.Application.ApplicationUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace CarWorkshopMVC.Application.ApplicationUser.Tests
{
    public class CurrentUserTests
    {
        [Fact()]
        public void IsInRole_WithMatchingROleShouldReturnTrue()
        {
            //arrange
            var currentUser = new CurrentUser("1", "test@test.com", new List<string> { "Admin", "User" });
            //act
            var isInRole = currentUser.IsInRole("Admin");
            //assert
            isInRole.Should().BeTrue();
        }

        [Fact()]
        public void IsInRole_WithMatchingRoleShouldReturnFalse()
        {
            //arrange
            var currentUser = new CurrentUser("1", "test@test.com", new List<string> { "Owner", "User" });
            //act
            var isInRole = currentUser.IsInRole("Admin");
            //assert
            isInRole.Should().BeFalse();
        }

        public void IsInRole_WithMatchingCaseRoleShouldReturnFalse()
        {
            //arrange
            var currentUser = new CurrentUser("1", "test@test.com", new List<string> { "Admin", "User" });
            //act
            var isInRole = currentUser.IsInRole("admin");
            //assert
            isInRole.Should().BeFalse();
        }
    }
}