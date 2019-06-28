using System;
using System.Collections.Generic;

namespace MontyHall
{
    internal class MontyHallGame
    {
        private readonly Random _random;

        public MontyHallGame(int noOfsimulations, Contestant contestant, Host host)
        {
            NoOfSimulations = noOfsimulations;
            _random = new Random((int) DateTime.Now.Ticks);
            Contestant = contestant;
            Host = host;
        }

        public int NoOfSimulations { get; set; }
        public List<bool> Boxes { get; set; }
        public Host Host { get; set; }
        public Contestant Contestant { get; set; }

        #region MontyHallGame Logic

        public void RunGameSimulation()
        {
            for (var i = 0; i < NoOfSimulations; i++)
            {
                ScrambleBoxes();
                SelectBoxRandomly(Contestant);
                ValidateScenario(Contestant, Host);

                if (Contestant.ChosenBox)
                    Contestant.Wins++;
            }
            
            // Calculate percentage of wins
            var doublePercentage = (double) Contestant.Wins / NoOfSimulations * 100;
            Contestant.WinPercentage = Convert.ToInt32(Math.Round(doublePercentage, 0));
        }

        public void ScrambleBoxes()
        {
            Boxes = new List<bool> {false, false, false};
            Boxes[_random.Next(0, 3)] = true;
        }

        public void SelectBoxRandomly(Player player)
        {
            var result = _random.Next(0, Boxes.Count);
            player.ChosenBox = Boxes[result];
            Boxes.RemoveAt(result);
        }

        // - SwapBox: Contestant swaps at the end.
        // - ChosenBox: Current state of choice
        // - RandomReveal: Host randomly reveals a box instead of knowingly revealing an empty box.
        public void ValidateScenario(Contestant con, Host hos)
        {
            if (con.SwapBox && con.ChosenBox)
            {
                // Contestant looses after swap.
                con.ChosenBox = false;
            }
            else if (con.SwapBox && con.ChosenBox == false)
            {
                if (hos.RandomReveal)
                {
                    // Let the game play out since host randomly reveals a box.
                    SelectBoxRandomly(Host);
                    con.ChosenBox = Boxes[0];
                }
                else
                {
                    // Host reveals empty box, contestant wins after swap.
                    con.ChosenBox = true;
                }
            }
        }

        #endregion
    }
}