using CombinatorialTheoryOfNumbers.LibDotNet;
using CombinatorialTheoryOfNumbers.LibDotNet.AdvancedStrategy;
using CombinatorialTheoryOfNumbers.LibDotNet.LinearStrategy;
using CombinatorialTheoryOfNumbers.LibDotNet.RandomStrategy;
using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace CombinatorialTheoryOfNumbers.AppDotNet
{
    class Program
    {
        static void Main(string[] args)
        {
            // no arguments - manual variable input
            // one argument - import tests from a json
            // two arguments - import tests form a json, export results to a file

            if(args.Length > 0)
            {
                string targetFile = "";
                List<Test> testList;
                TextWriter originalWriter = Console.Out;
                StreamWriter streamWriter = null;
                Console.WriteLine($"Loading JSON input from file {args[0]}...");
                try
                {
                    testList = JsonConvert.DeserializeObject<List<Test>>(File.ReadAllText(args[0]));
                }
                catch(Exception e)
                {
                    Console.WriteLine($"Failed to load the JSON input.\n{e.ToString()}");
                    return;
                }
                Console.WriteLine($"Successfully loaded {testList.Count} test(s) from file.");

                if(args.Length == 2)
                {
                    targetFile = args[1];

                    streamWriter = new StreamWriter(targetFile);
                    Console.SetOut(streamWriter);
                }
                for(int i = 0; i < testList.Count; i ++)
                {
                    testList[i].Run(i+1);
                }
                if(targetFile != "")
                {
                    Console.SetOut(originalWriter);
                    streamWriter.Close();
                }
                Console.WriteLine("Done.");
                Console.WriteLine("Press any key to quit.");
                Console.ReadKey(true);
                return;
            }

            string P1type, P2type;
            int k, c, l;
            int seed1, seed2;

            P1type = "";
            P2type = "";
            k = 0;
            c = 0;
            l = 0;
            seed1 = 0;
            seed2 = 0;

            try
            {
                Console.Write("Enter K: ");
                k = int.Parse(Console.ReadLine());
                Console.Write("Enter C: ");
                c = int.Parse(Console.ReadLine());
                Console.Write("Enter L: ");
                l = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Player 1 type.");
                Console.WriteLine("Available: advanced, linear, random, manual");
                P1type = Console.ReadLine();
                if(P1type.ToLower() == "random")
                {
                    Console.Write("Enter player 1's random seed: ");
                    seed1 = int.Parse(Console.ReadLine());
                }
                Console.WriteLine("Enter Player 2 type.");
                Console.WriteLine("Available: advanced, linear, random, manual");
                P2type = Console.ReadLine();
                if (P2type.ToLower() == "random")
                {
                    Console.Write("Enter player 2's random seed: ");
                    seed2 = int.Parse(Console.ReadLine());
                }
            }
            catch(Exception e)
            {
                Console.WriteLine($"Caught exception.\n{e.ToString()}");
                return;
            }

            string presenter;
            if (c > ColoredStatePresenter.ForegroundColors.Length)
            {
                presenter = "long";
            }
            else
            {
                presenter = "colored";
            }
            Test quickTest = new Test(presenter, P1type, seed1, P2type, seed2, k, c, l, 1);
            quickTest.Run();
            Console.WriteLine("Press any key to quit.");
            Console.ReadKey(true);
            return;
        }
    }
}
