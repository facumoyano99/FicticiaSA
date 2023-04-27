using Microsoft.Extensions.Configuration;

namespace FicticiaSA.Helpers.Config
{
    public class Config : IConfig
    {
        private readonly IConfiguration configuration;

        public Config(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string GetConectionDB()
        {
            return configuration.GetConnectionString("DefaultConnection");
        }  
        public string GetJwt()
        {
            return configuration["Jwt"];
        }
        
    }
}
