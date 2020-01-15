using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CadastroProdutos.Application.Exceptions;
using CadastroProdutos.Application.Requests;
using CadastroProdutos.Domain.Entity;
using CadastroProdutos.Domain.Interface.Service;
using CadastroProdutos.Domain.Notifications;

namespace CadastroProdutos.Application.Handlers
{
    public class 
        AuthenticateHandler : IRequestHandler<AuthenticateRequest, object>
    {
        NotificationContext _notificationContext;
        private readonly IJwtService _jwtService;
        private readonly IUserService _userService;
        private readonly IRefreshTokenService _refreshTokenService;

        public AuthenticateHandler(
            NotificationContext notificationContext,
            IJwtService jwtService,
            IUserService userService,
            IRefreshTokenService refreshTokenService)
        {
            _notificationContext = notificationContext;
            _jwtService = jwtService;
            _userService = userService;
            _refreshTokenService = refreshTokenService;
        }

        public async Task<object> Handle(AuthenticateRequest request, CancellationToken cancellationToken)
        {
            User user = null;

            try
            {
                if (request.GrantType.Equals("password"))
                {
                    user = await HandleUserAuthentication(request);
                }
                
                if (_notificationContext.HasNotifications || user == null)
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                //Logging.Error("Authentication error", ex);
                throw new ApplicationServiceException("Authentication error", ex);
            }


            return await HandleJwt(user);
        }

        private async Task<object> HandleJwt(User user)
        {
            var jwt = _jwtService.CreateJWT(user);
            await _refreshTokenService.Save(jwt.RefreshToken);

            return (new
            {
                accessToken = jwt.AccessToken,
                refreshToken = jwt.RefreshToken.Token,
                tokenType = jwt.TokenType,
                expiresIn = jwt.ExpiresIn
            });
        }

        private async Task<User> HandleUserAuthentication(AuthenticateRequest request)
        {
            var user = await _userService.Authenticate(request.Email, request.Password);

            if (user == null)
            {
                _notificationContext.AddNotification("authenticate", "Usuário ou senha inválidos");
                return null;
            }

            return user;
        }

    }
}
