using MediatR;
namespace ShipWebService.Commands.UpdateShip;
public class UpdateShipCommand : IRequest
{
    public int Id { get; set; }
    public ShipDTO Ship { get; set; }
}