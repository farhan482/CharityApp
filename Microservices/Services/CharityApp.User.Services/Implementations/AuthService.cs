using CharityApp.DTOS.Auth;
using CharityApp.Helpers;
using CharityApp.ResponseModels;
using CharityApp.User.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace CharityApp.User.Services.Implementations
{
    public class AuthService : IAuthService
    {
        public async Task<RequestResponse<string>> LoginAsync(LoginDto request)
        {
            var response = new RequestResponse<string>();

            if (request.Username == "Admin" && request.Password == "Admin@123")
            {
                var token = await GenerateToken();
                response.Result = token.Token;

                response.StatusCode = HttpStatusCode.OK;
                response.Message = "User Logged In Successfully !";
            }
            return response;
        }

        #region Private Methods
        private async Task<TokenResponse> GenerateToken()
        {
            var response = new TokenResponse();

            await Task.Run(() => 
            {
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ConfigsSettings.JWT.SECRET_KEY));

                var tokenHandler = new JwtSecurityTokenHandler();
                var claims = new List<Claim>()
                    {
                        new Claim("Username","ADMIN"),
                        new Claim(ClaimTypes.Role,"SuperAdmin")
                    };
                var tokenDescriptor = new SecurityTokenDescriptor()
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = ConfigsSettings.JWT.EXPIRATION_TIME,
                    Audience = ConfigsSettings.JWT.AUDIENCE,
                    Issuer = ConfigsSettings.JWT.ISSUER,
                    SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature)
                };
                var tokenCreation = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(tokenCreation);
                response.Token = token;
            });

            return response;
        }
        #endregion
    }
}
