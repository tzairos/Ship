using ApplicationCore.Interfaces;
namespace ApplicationCore.Entities.UserAggreate;
public class User: BaseEntity,IAggregateRoot{
    public int Id{get;set;}
    public string Username { get; set; }
    public string Password { get; set; }
}