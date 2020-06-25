using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ucommerce.Infrastructure.Configuration;
using Ucommerce.Installer;

namespace RunningUCommerce.ConnectionStringLocator
{
    public class InstallationIntegrationTestConnectionStringLocator : Ucommerce.Installer.IInstallationConnectionStringLocator
    {
        public string LocateConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["uCommerce"].ConnectionString;
        }
    }

    public class IntegrationTestConnectionStringLocator : InstallationConnectionStringLocator, IConnectionStringLocator
    {
        public override string LocateConnectionString()
        {
            return base.LocateConnectionStringInternal("ucommerce");
        }
    }
}
