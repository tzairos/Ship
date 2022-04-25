

using ApplicationCore.Entities.UserAggreate;
using ApplicationCore.Interfaces;
using ApplicationCore.Spesifications;

public class UserService : IUserService
{

    private readonly IRepository<User> _userRepository;
    public UserService(IRepository<User> userRepository)
    {
        _userRepository=userRepository;
    }
    public async Task<User> GetUser(string userName,string password)
    {
    UserSpesification spec=new UserSpesification(userName,password);

      var result= await _userRepository.GetBySpesification(spec);
      if(result?.Count()==0){
          throw new Exception("User not found");
      }
      else{
          return result.FirstOrDefault();
      }
    }

    public Task<User> GetUser()
    {
        throw new NotImplementedException();
    }

    public async Task<User> GetUserByIdAsync(int id)
    {
          var result= await _userRepository.GetByIdAsync(id);
      if(result==null){
          throw new Exception("User not found");
      }
      else{
          return result;
      }
    }

    public Task<User> Removeuser()
    {
        throw new System.NotImplementedException();
    }

    public Task<User> Updateuser()
    {
        throw new System.NotImplementedException();
    }
  
}