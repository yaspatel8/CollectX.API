using System;
using System.Collections.Generic;
using System.Text;

namespace CollectX.API.Contracts.Settings
{
    public class CorsSettings
    {
        public const string SectionName = "CorsSettings";

        /// <summary>
        /// Allowed browser origins for credentialed CORS (e.g. TXBrokerCRM-App dev server).
        /// </summary>
        public string[] AllowedOrigins { get; set; } = [];
    }
}
