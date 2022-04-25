using FluentValidation;
namespace ShipWebService.Commands.DeleteShip;

public class DeleteShipCommandValidation : AbstractValidator<DeleteShipCommand>
{
    public DeleteShipCommandValidation()
    {
        RuleFor(x => x.Id).GreaterThan(0).LessThan(int.MaxValue);
    }
}
