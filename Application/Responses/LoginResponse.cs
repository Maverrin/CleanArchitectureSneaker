namespace Application.Responses;

public class LoginResponse
{
    public string Status { get; set; }
    public string Message { get; set; }

    //Auth
    public string Email { get; set; }
    public string Token { get; set; }
}
