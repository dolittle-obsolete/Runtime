/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using System.Threading.Tasks;
using Dolittle.Booting;

namespace Streams
{

    public class BootProcedure : ICanPerformBootProcedure
    {
        readonly InputStreamGenerator _inputStreamGenerator;
        readonly OutputStreamOutputter _outputStreamOutputter;

        public BootProcedure(InputStreamGenerator inputStreamGenerator, OutputStreamOutputter outputStreamOutputter)
        {
            _inputStreamGenerator = inputStreamGenerator;
            _outputStreamOutputter = outputStreamOutputter;
        }

        public bool CanPerform() => true;

        public void Perform()
        {
            _outputStreamOutputter.Start();
            
            Task.Run(() =>
            {
                Console.WriteLine("\n\n");
                Console.WriteLine("To start streaming data into input stream, press 'I'");
                Console.WriteLine("\n\n");

                for (;;)
                {
                    var key = Console.ReadKey();
                    if (key.Key == ConsoleKey.I) _inputStreamGenerator.Start();
                }
            });
        }
    }
}