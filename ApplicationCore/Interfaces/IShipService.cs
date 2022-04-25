using System.Threading.Tasks;
namespace ApplicationCore.Interfaces;
public interface IShipService
{
   
    Task<ApplicationCore.Entities.ShipAggreate.Ship> AddShip();
    Task<ApplicationCore.Entities.ShipAggreate.Ship> UpdateShip();
    Task<ApplicationCore.Entities.ShipAggreate.Ship> RemoveShip();
  
}
