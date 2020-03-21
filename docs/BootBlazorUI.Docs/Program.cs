using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using EmbeddedBlazorContent;

namespace BootBlazorUI.Docs
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static string GetVersion(bool full = false)
        {
            var version = typeof(BaseComponent).Assembly.GetName().Version;
            if (version == null)
            {
                return string.Empty;
            }
            if (full)
            {
                return version.ToString();
            }
            return $"{version.Major}.{version.Minor}.{version.Build}";
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
