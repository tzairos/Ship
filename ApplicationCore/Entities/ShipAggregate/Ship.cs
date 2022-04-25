using ApplicationCore.Interfaces;
namespace ApplicationCore.Entities.ShipAggreate;
public class Ship: BaseEntity,IAggregateRoot{
    public int Length { get; set; }

    public string Name { get; set; }

    public int Width { get; set; }
    public string Code { get; set; }
    public  int Id { get;  set; }
}