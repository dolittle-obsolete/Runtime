/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Threading.Tasks;
using Dolittle.Booting;
using Microsoft.Extensions.Hosting;

namespace Boot
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Bootloader.Configure(_ => {
            }).Start();

            var hostBuilder = new HostBuilder();
            hostBuilder.UseEnvironment("Development");
            await hostBuilder.RunConsoleAsync();
        }
    }
}
