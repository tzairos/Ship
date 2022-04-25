
using ApplicationCore.Entities.ShipAggreate;

namespace ApplicationCore.Spesifications;
public class ShipSpesification : BaseSpecification<Ship>
{

    public ShipSpesification(string code, string name, int? width, int? length)
    : base(
        shipFilter =>
        (string.IsNullOrEmpty(code) || shipFilter.Code == code) &&
        (string.IsNullOrEmpty(name) || shipFilter.Name == name) &&
        (!width.HasValue || shipFilter.Width == width) &&
        (!length.HasValue || shipFilter.Length == length)
        )
    {

    }
}