using FluentValidation;
namespace ShipWebService.Queries.GetShip;

public class GetShipQueryValidation : AbstractValidator<GetShipQuery>
{
    public GetShipQueryValidation()
    {
        When(x => x.Filter != null, () =>
        {
            RuleFor(x => x.Filter.Code).Matches("[A-Z]*-[0-9]*-[A-Z][0-9]").When(x => !String.IsNullOrEmpty(x.Filter.Code));
            RuleFor(x => x.Filter.Width).GreaterThan(0).LessThan(int.MaxValue).When(x => x.Filter.Width != default);
            RuleFor(x => x.Filter.Length).GreaterThan(0).LessThan(int.MaxValue).When(x => x.Filter.Width != default); ;
        });
        RuleFor(x => x.Id).GreaterThan(0).LessThan(int.MaxValue).When(x => x.Id != default);
    }
}