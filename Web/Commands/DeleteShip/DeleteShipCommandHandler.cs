using MediatR;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Entities.ShipAggreate;
using AutoMapper;

namespace ShipWebService.Commands.DeleteShip;
public class DeleteShipCommandHandler : IRequestHandler<DeleteShipCommand, Unit>
{

    private readonly IRepository<Ship> _shipRepository;
    private readonly IMapper _mapper;

    public DeleteShipCommandHandler(IRepository<Ship> shipRepository,IMapper mapper)
    {
        _shipRepository=shipRepository;
        _mapper = mapper;
    }  
    public async Task<Unit> Handle(DeleteShipCommand request, CancellationToken cancellationToken)
    {
        var shipEntity= await _shipRepository.GetByIdAsync(request.Id);
        await _shipRepository.DeleteAsync(shipEntity);
        return Unit.Value;
    }
}