namespace MontyHall
{
    internal class Contestant : Player
    {
        public Contestant(bool swapBox)
        {
            SwapBox = swapBox;
        }

        public bool SwapBox { get; set; }
        public int Wins { get; set; }
        public int WinPercentage { get; set; }
    }
}