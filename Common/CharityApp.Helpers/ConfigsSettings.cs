using Microsoft.Extensions.Configuration;

namespace CharityApp.Helpers
{
    public class ConfigsSettings
    {
        private readonly IConfiguration _configuration;

        public ConfigsSettings(IConfiguration configuration)
        {
            _configuration = configuration;
            #region JWT Initilization From Configuration
            JWT.SECRET_KEY = _configuration.GetSection("JWT").GetValue<string>("SecretKey");
            JWT.AUDIENCE = _configuration.GetSection("JWT").GetValue<string>("Audience");
            JWT.ISSUER = _configuration.GetSection("JWT").GetValue<string>("Issuer");
            JWT.EXPIRATION_TIME = DateTime.UtcNow.AddDays(10);
            #endregion
        }
        public class JWT
        {
            public static DateTime EXPIRATION_TIME { get; set; }
            public static string SECRET_KEY { get; set; }
            public static string AUDIENCE { get; set; }
            public static string ISSUER { get; set; }
        }
    }
}
