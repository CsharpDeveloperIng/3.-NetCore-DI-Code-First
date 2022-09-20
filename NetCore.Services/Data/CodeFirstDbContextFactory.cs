using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using NetCore.Services.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCore.Services.Data
{
    public class CodeFirstDbContextFactory : IDesignTimeDbContextFactory<CodeFirstDbContext>
    {
        private const string _ConfigPath = @"D:\1. Program\1. ASP.NET\MVC\3. NetCore DI&Code-First\NetCore.Web\appsettings.json";

        public CodeFirstDbContext CreateDbContext(string[] args)
        {
            var optionsBuiilder = new DbContextOptionsBuilder<CodeFirstDbContext>();
            optionsBuiilder.UseSqlServer(new DbConnector(_ConfigPath).GetConnectionString());
            return new CodeFirstDbContext(optionsBuiilder.Options);
        }
    }
}
