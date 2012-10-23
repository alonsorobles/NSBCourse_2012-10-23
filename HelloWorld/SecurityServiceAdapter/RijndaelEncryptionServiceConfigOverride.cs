using NServiceBus.Config;
using NServiceBus.Config.ConfigurationSource;

namespace SecurityServiceAdapter
{
    public class RijndaelEncryptionServiceConfigOverride : IProvideConfiguration<RijndaelEncryptionServiceConfig>
    {
        public RijndaelEncryptionServiceConfig GetConfiguration()
        {
            return new RijndaelEncryptionServiceConfig
                {
                    // this key could be fetched from a REST/WS/DB call
                    Key = "gdDbqRpqdRbTs3mhdZh9qCaDaxJXl+e7"
                };
        }
    }
}
