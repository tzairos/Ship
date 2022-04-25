using MediatR;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Entities.ShipAggreate;
using AutoMapper;

namespace ShipWebService.Commands.AddShip;
public class AddShipCommandHandler : IRequestHandler<AddShipCommand, Unit>
{

    private readonly IRepository<Ship> _shipRepository;
    private readonly IMapper _mapper;

    public AddShipCommandHandler(IRepository<Ship> shipRepository,IMapper mapper)
    {
        _shipRepository=shipRepository;
        _mapper = mapper;
    }  
    public Task<Unit> Handle(AddShipCommand request, CancellationToken cancellationToken)
    {

        var ship =_mapper.Map<Ship>(request.Ship);
        _shipRepository.AddAsync(ship);
        return Unit.Task;
    }
}