using System;

namespace MontyHall
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Number of simulations: ");

            var noOfSimulations = int.Parse(Console.ReadLine());


            /* An instance of a game-session(simulation) needs: 
                  1. Number of simulations.
                  2. Two players: One contestant, and one host.
            */

            // Simulation 1: With swap.
            var simulationSwap = new MontyHallGame(noOfSimulations, new Contestant(true), new Host(false));
            simulationSwap.RunGameSimulation();
            PrintResults(simulationSwap);

            // Simulation 2: With swap and random host.
            var simulationSwapRandom = new MontyHallGame(noOfSimulations, new Contestant(true), new Host(true));
            simulationSwapRandom.RunGameSimulation();
            PrintResults(simulationSwapRandom);

            // Simulation 3: Without swap, type of host doesn't matter for this simulation since contestant keeps first choice.
            var simulationNoSwap = new MontyHallGame(noOfSimulations, new Contestant(false), new Host(false));
            simulationNoSwap.RunGameSimulation();
            PrintResults(simulationNoSwap);
        }

        private static void PrintResults(MontyHallGame montyHallGame)
        {
            Console.WriteLine("With switch: " + montyHallGame.Contestant.SwapBox);
            Console.WriteLine("Random host: " + montyHallGame.Host.RandomReveal);
            Console.WriteLine("Wins total: " + montyHallGame.Contestant.Wins + " / " + montyHallGame.NoOfSimulations);
            Console.WriteLine("Win percentage: " + montyHallGame.Contestant.WinPercentage + "%");
            Console.WriteLine(Environment.NewLine);
        }
    }
}