﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Ecommerce.Api
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Program'
    public class Program
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Program'
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Program.Main(string[])'
        public static void Main(string[] args)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Program.Main(string[])'
        {
            CreateWebHostBuilder(args).Build().Run();
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Program.CreateWebHostBuilder(string[])'
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Program.CreateWebHostBuilder(string[])'
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
