using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Entities.ShipAggreate;
using FluentValidation.TestHelper;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using ShipWebService.Commands.AddShip;

namespace Web.Tests;

[TestFixture]
public class AddShipCommandValidationTests : BaseTest
{
    private  AddShipCommandValidation validator;
    [Test]
    public async Task Given_Invalid_Code_Command_When_AddShipCommand_Sent_Then_Returns_False()
    {
    validator=new AddShipCommandValidation();
     AddShipCommand command = new AddShipCommand();
        command.Ship = new ShipDTO()
        {
            Code = "testCode",
            Name = "testName",
            Length = 1,
            Width = 1
        };
      var result = validator.TestValidate(command);
      
           Assert.AreEqual(false, result.IsValid);
    }
    [Test]
    public async Task Given_Valid_Code_Command_When_AddShipCommand_Sent_Then_Returns_True()
    {
    validator=new AddShipCommandValidation();
     AddShipCommand command = new AddShipCommand();
        command.Ship = new ShipDTO()
        {
            Code = "AAAA-1111-A1",
            Name = "testName",
            Length = 1,
            Width = 1
        };
      var result = validator.TestValidate(command);
      
           Assert.AreEqual(true, result.IsValid);
    }
}