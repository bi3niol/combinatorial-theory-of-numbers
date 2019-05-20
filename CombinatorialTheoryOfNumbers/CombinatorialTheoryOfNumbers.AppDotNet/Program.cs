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
                List<Test> testList;
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

                if(args.Length == 1)
                {
                    IStatePresenter<int, int> pres1 = new ColoredStatePresenter();
                    IStatePresenter<int, int> pres2 = new LongStatePresenter();
                    for (int i = 0; i < testList.Count; i ++)
                    {
                        Test test = testList[i];
                        IPlayer1<int,int> P1 = test.GetPlayer1();
                        IPlayer2<int, int> P2 = test.GetPlayer2();
                        if (P1 == null || P2 == null)
                        {
                            Console.WriteLine($"Failed to execute test {i} - incorrect player type(s).");
                            continue;
                        }
                        Console.WriteLine($"Test {i}: {P1.GetType().Name} vs {P2.GetType().Name}");
                        IStatePresenter<int, int> pres = pres1;
                        if (test.C >= ColoredStatePresenter.ForegroundColors.Length)
                        {
                            pres = pres2;
                        }
                         var winner = test.Run(pres);
                        Console.WriteLine(winner.GetType().Name + " won!");
                    }
                }
                else
                {
                    Console.WriteLine($"Will be writing to the file {args[1]}.");
                    FileStatePresenter pres = new FileStatePresenter(args[1]);
                    for (int i = 0; i < testList.Count; i++)
                    {
                        Test test = testList[i];
                        var P1 = test.GetPlayer1();
                        var P2 = test.GetPlayer2();
                        if (P1 == null || P2 == null)
                        {
                            pres.WriteString($"Failed to execute test {i} - incorrect player type(s).");
                            continue;
                        }
                        pres.WriteString($"Test {i}: {P1.GetType().Name} vs {P2.GetType().Name}");
                        var winner = test.Run(pres);
                        pres.WriteString(winner.GetType().Name + " won!");
                    }
                    pres.Close();
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

            IStatePresenter<int, int> presenter;
            if (c > ColoredStatePresenter.ForegroundColors.Length)
            {
                presenter = new LongStatePresenter();
            }
            else
            {
                presenter = new ColoredStatePresenter();
            }
            Test quickTest = new Test(P1type, seed1, P2type, seed2, k, c, l);
            var quickWinner = quickTest.Run(presenter);
            if(quickWinner == null)
            {
                Console.WriteLine("Failed to execute test - wrong player types.");
            }
            else
            {
                Console.WriteLine(quickWinner.GetType().Name + " won!");
            }
            Console.WriteLine("Press any key to quit.");
            Console.ReadKey(true);
        }
    }
}
