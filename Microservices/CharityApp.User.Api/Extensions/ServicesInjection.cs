using CharityApp.Helpers;
using CharityApp.User.Services.Implementations;
using CharityApp.User.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CharityApp.User.Api.Extensions
{
    public static class ServicesInjection
    {
        public static IServiceCollection ServicesRegistration(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(opt =>
            {
                var key = Encoding.UTF8.GetBytes(ConfigsSettings.JWT.SECRET_KEY);

                opt.SaveToken = true;
                opt.RequireHttpsMetadata = true;
                opt.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    ValidAudience = ConfigsSettings.JWT.AUDIENCE,
                    ValidIssuer = ConfigsSettings.JWT.ISSUER,
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };
            });

            services.AddSingleton(new ConfigsSettings(configuration));
            services.AddScoped<IAuthService, AuthService>();
            return services;
        }
    }
}
