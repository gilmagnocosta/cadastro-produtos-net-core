using MediatR;

namespace CadastroProdutos.Application.Requests
{
    public class AuthenticateRequest : IRequest<object>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string GrantType { get; set; }
        public string RefreshToken { get; set; }

        public AuthenticateRequest() { }

        public AuthenticateRequest(string grantType, string email, string password, string refreshToken)
        {
            GrantType = grantType;
            Email = email;
            Password = password;
            RefreshToken = refreshToken;
        }
    }
}
