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

        public static string GetVersion(bool full = false,int? preview=2)
        {
            var version = typeof(BootComponentBase).Assembly.GetName().Version;
            if (version == null)
            {
                return string.Empty;
            }
            if (full)
            {
                return version.ToString();
            }
            return $"{version.Major}.{version.Minor}.{version.Build}{(preview.HasValue?$"-preview{preview}":"")}";
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
