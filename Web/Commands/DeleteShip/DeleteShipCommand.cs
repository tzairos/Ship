using MediatR;
namespace ShipWebService.Commands.DeleteShip;
public class DeleteShipCommand : IRequest
{
    public int Id { get; set; }
}