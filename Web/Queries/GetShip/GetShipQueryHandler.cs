using MediatR;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Entities.ShipAggreate;
using AutoMapper;
using ApplicationCore.Spesifications;

namespace ShipWebService.Queries.GetShip;
public class GetShipQueryHandler : IRequestHandler<GetShipQuery, IEnumerable<ShipDTO>>
{

    private readonly IRepository<Ship> _shipRepository;
    private readonly IMapper _mapper;

    public GetShipQueryHandler(IRepository<Ship> shipRepository, IMapper mapper)
    {
        _shipRepository = shipRepository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<ShipDTO>> Handle(GetShipQuery request, CancellationToken cancellationToken)
    {
        List<Ship> returnShipList = new List<Ship>();
        if (request.Id != default)
        {
            var ship = await _shipRepository.GetByIdAsync(request.Id.Value);
            returnShipList.Add(ship);
        }
        else
        {
            ShipSpesification spesification=new ShipSpesification(request.Filter?.Code,request.Filter?.Name,request.Filter?.Width,request.Filter?.Length);
           
            var resultList = await _shipRepository.GetBySpesification(spesification);
            returnShipList.AddRange(resultList);
        }
        return _mapper.Map<IEnumerable<ShipDTO>>(returnShipList);
    }
}