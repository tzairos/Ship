

using ApplicationCore.Entities.ShipAggreate;
using ApplicationCore.Interfaces;

public class ShipService : IShipService
{

    private readonly IRepository<Ship> _shipRepository;
    public ShipService(IRepository<Ship> shipRepository)
    {
        _shipRepository=shipRepository;
    }
    public async Task<ApplicationCore.Entities.ShipAggreate.Ship> AddShip()
    {
    
      await _shipRepository.AddAsync(new Ship());
      return null;
    }

    public Task<ApplicationCore.Entities.ShipAggreate.Ship> RemoveShip()
    {
        throw new System.NotImplementedException();
    }

    public Task<ApplicationCore.Entities.ShipAggreate.Ship> UpdateShip()
    {
        throw new System.NotImplementedException();
    }
}