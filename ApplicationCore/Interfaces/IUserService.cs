using System.Threading.Tasks;
namespace ApplicationCore.Interfaces;
public interface IUserService
{
   
    Task<ApplicationCore.Entities.UserAggreate.User> GetUser(string userName,string password);
    Task<ApplicationCore.Entities.UserAggreate.User> GetUserByIdAsync(int id);
   
  
}
