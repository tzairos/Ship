using FluentValidation;
namespace ShipWebService.Commands.AddShip;

public class AddShipCommandValidation : AbstractValidator<AddShipCommand>
{
  public AddShipCommandValidation()
  {
    RuleFor(x => x.Ship).NotNull();

   When(x => x.Ship!=null, () => {
   RuleFor(x => x.Ship.Code).NotEmpty().NotNull().Matches("[A-Z]*-[0-9]*-[A-Z][0-9]");
   RuleFor(x => x.Ship.Name).NotEmpty().NotNull();
   RuleFor(x => x.Ship.Width).GreaterThan(0).LessThan(int.MaxValue);
   RuleFor(x => x.Ship.Length).GreaterThan(0).LessThan(int.MaxValue);
});
  }
}

//AAAA-1111-A1 