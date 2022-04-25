using ApplicationCore.Spesifications;
using MediatR;
namespace ShipWebService.Queries.GetShip;
public class GetShipQuery : IRequest<IEnumerable<ShipDTO>>
{
    
    public int? Id { get; set; }
    public ShipDTO? Filter { get; set; }
}