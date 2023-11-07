using Xunit;
using CarWorkshopMVC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace CarWorkshopMVC.Domain.Entities.Tests
{
    public class CarWorkshopTests
    {
        [Fact()]
        public void EncodeNameTest_ShouldSetEncodedName()
        {
            //arrange
            var carWorkShop = new CarWorkshop();
            carWorkShop.Name = "Test Workshop";

            //act
            carWorkShop.EncodeName();
            //assert
            carWorkShop.EncodedName.Should().Be("test-workshop");
        }

        [Fact()]
        public void EncodedName_ShouldThrowExceptions_WhenNameIsNull()
        {
            //arrange
            var carWorkshop = new CarWorkshop();
            //act
            Action action = ()=>carWorkshop.EncodeName();
            //assert
            action.Invoking(a=>a.Invoke())
                .Should().Throw<NullReferenceException>();
        }
    }
}