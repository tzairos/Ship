using MediatR;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Entities.ShipAggreate;
using AutoMapper;

namespace ShipWebService.Commands.UpdateShip;
public class UpdateShipCommandHandler : IRequestHandler<UpdateShipCommand, Unit>
{

    private readonly IRepository<Ship> _shipRepository;
    private readonly IMapper _mapper;

    public UpdateShipCommandHandler(IRepository<Ship> shipRepository,IMapper mapper)
    {
        _shipRepository=shipRepository;
        _mapper = mapper;
    }  
    public async Task<Unit> Handle(UpdateShipCommand request, CancellationToken cancellationToken)
    {
        var shipEntity=_mapper.Map<Ship>(request.Ship);
        shipEntity.Id=request.Id;
        await _shipRepository.UpdateAsync(shipEntity);
        return Unit.Value;
    }
}