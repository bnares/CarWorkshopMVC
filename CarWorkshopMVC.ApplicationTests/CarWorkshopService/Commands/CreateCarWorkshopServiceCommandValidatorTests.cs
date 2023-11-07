using Xunit;
using CarWorkshopMVC.Application.CarWorkshopService.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarWorkshopMVC.Application.Commands.CreateCarWorksop;
using FluentValidation.TestHelper;

namespace CarWorkshopMVC.Application.CarWorkshopService.Commands.Tests
{
    public class CreateCarWorkshopServiceCommandValidatorTests
    {
        [Fact()]
        public void Validate_WithValidCommand_ShouldHaeValidatorError()
        {
            //arrange
            var validator = new CreateCarWorkshopServiceCommandValidator();
            var comand = new CreateCarWorkshopServiceCommand()
            {
                Cost = "100PLN",
                Description = "Description",
                CarWorkshopEncodedName = "workshop1"
            };
            //act
            var result = validator.TestValidate(comand);
            //assert
            result.ShouldNotHaveAnyValidationErrors();
        }


        [Fact()]
        public void Validate_WithInvalidCommand_ShouldHaeValidatorError()
        {
            //arrange
            var validator = new CreateCarWorkshopServiceCommandValidator();
            var comand = new CreateCarWorkshopServiceCommand()
            {
                Cost = "",
                Description = "",
                CarWorkshopEncodedName = null
            };
            //act
            var result = validator.TestValidate(comand);
            //assert
            result.ShouldHaveValidationErrorFor(x => x.Cost);
            result.ShouldHaveValidationErrorFor(x => x.Description);
            result.ShouldHaveValidationErrorFor(x => x.CarWorkshopEncodedName);
        }
    }
}