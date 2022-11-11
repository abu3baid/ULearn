﻿namespace CsvWorker.infrastructure
{
    public interface IConfigurationSettings
    {
        string JwtKey { get; }

        string Issuer { get; }

        string WebSiteURl { get; }
    }
}
