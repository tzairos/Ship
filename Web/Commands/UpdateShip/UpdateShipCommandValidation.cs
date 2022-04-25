using FluentValidation;
namespace ShipWebService.Commands.UpdateShip;

public class UpdateShipCommandValidation : AbstractValidator<UpdateShipCommand>
{
  public UpdateShipCommandValidation()
  {
    RuleFor(x => x.Ship).NotNull();

   RuleFor(x => x.Id).GreaterThan(0).LessThan(int.MaxValue);
   When(x => x.Ship!=null, () => {
   RuleFor(x => x.Ship.Code).NotEmpty().NotNull().Matches("[A-Z]*-[0-9]*-[A-Z][0-9]");
   RuleFor(x => x.Ship.Name).NotEmpty().NotNull();
   RuleFor(x => x.Ship.Width).GreaterThan(0).LessThan(int.MaxValue);
   RuleFor(x => x.Ship.Length).GreaterThan(0).LessThan(int.MaxValue);
});
  }
}

//AAAA-1111-A1 