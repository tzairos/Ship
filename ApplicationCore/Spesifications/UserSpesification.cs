
using ApplicationCore.Entities.UserAggreate;

namespace ApplicationCore.Spesifications;
public class UserSpesification : BaseSpecification<User>
{

    public UserSpesification(string userName, string password)
    : base(
        shipFilter =>
        (string.IsNullOrEmpty(userName) || shipFilter.Password == password) &&
        (string.IsNullOrEmpty(password) || shipFilter.Username == userName)
        )
    {

    }
}