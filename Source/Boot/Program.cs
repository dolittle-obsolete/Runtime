/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Threading.Tasks;
using Dolittle.Booting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Boot
{

    class Program
    {
        static async Task Main(string[] args)
        {
            //while(!System.Diagnostics.Debugger.IsAttached) System.Threading.Thread.Sleep(10);

            var hostBuilder = new HostBuilder();
            hostBuilder.ConfigureLogging(_ => {
                _.AddConsole();
            });
            hostBuilder.UseEnvironment("Development");
            var host = hostBuilder.Build();
            var loggerFactory = host.Services.GetService(typeof(ILoggerFactory)) as ILoggerFactory;

            var result = Bootloader.Configure(_ => {
                _.UseLoggerFactory(loggerFactory);
                _.Development();
            }).Start();

            await host.RunAsync();
        }
    }
}
