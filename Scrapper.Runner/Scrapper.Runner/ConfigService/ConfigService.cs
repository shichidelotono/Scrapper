using JsonConfig;

namespace Scrapper.Runner.ConfigService
{
    public class ConfigService : IConfigService
    {
        public string GetApiEndpoint()
        {
            return Config.Default.ApiEndpoint;
        }
    }
}
