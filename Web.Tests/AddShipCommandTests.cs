using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Entities.ShipAggreate;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using ShipWebService.Commands.AddShip;

namespace Web.Tests;

[TestFixture]
public class AddShipCommandTests : BaseTest
{
    [Test]
    public async Task Given_Valid_AddShip_Command_When_AddShipCommand_Sent_Then_Adds_Successfully()
    {

        var sp = _services.BuildServiceProvider();

        var contextFactory = sp.GetService<IDbContextFactory<ShipContext>>();
        
        AddShipCommand command = new AddShipCommand();
        command.Ship = new ShipDTO()
        {
            Code = "testCode",
            Name = "testName",
            Length = 1,
            Width = 1
        };
       _mediator = sp.GetService<IMediator>();
        await _mediator.Send(command);
        Ship actualShip=null;
        await using (var context = contextFactory.CreateDbContext())
        {
            actualShip = context.Ships.Where(x => x.Name == "testName").FirstOrDefault();
         
        }
           Assert.AreEqual(command.Ship.Name, actualShip.Name);
    }
}