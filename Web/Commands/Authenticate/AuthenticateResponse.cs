public class AuthenticateResponse
{
    public int Id { get; set; }
 
    public string Username { get; set; }
    public string Token { get; set; }


    public AuthenticateResponse(UserDTO user)
    {
        Id = user.Id;
        Username = user.Username;
        Token = user.Token;
    }
}