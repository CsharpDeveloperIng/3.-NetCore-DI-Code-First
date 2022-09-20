using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace NetCore.Services.Config
{
    public class DbConnector
    {
        private  readonly string _connectionString =String.Empty;

        // Add Nuget Packages
        //  Microsoft.Extensions.Configuration.
        //  Microsoft.Extensions.Configuration.Abstractions
        //  Microsoft.Extensions.Configuration.Json
        // ctor tap tap 은 생성자 자동 생성
        public DbConnector(string configPath)
        {
            var ConfigBuilder = new ConfigurationBuilder();
            ConfigBuilder.AddJsonFile(configPath,false);
            //string ConnectionString = ConfigBuilder.Build()
            //                                               .GetSection("ConnectionStrings")
            //                                               .GetSection("DefaultConnection")
            //                                               .Value;
            _connectionString = ConfigBuilder.Build()["ConnectionStrings:DefaultConnection"];
        }
        public string GetConnectionString()
        {
            return _connectionString;
        }
    }
}
