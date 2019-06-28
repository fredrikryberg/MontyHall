namespace MontyHall
{
    internal class Host : Player
    {
        public Host(bool randomReveal)
        {
            RandomReveal = randomReveal;
        }

        public bool RandomReveal { get; set; }
    }
}