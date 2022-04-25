using MediatR;
namespace ShipWebService.Commands.AddShip;
public class AddShipCommand : IRequest
{
    public ShipDTO Ship { get; set; }=new ShipDTO();
}
