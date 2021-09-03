using Game.Interfaces;

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            IDiceGame dice = new DiceGame();
            dice.Initialize();
            dice.Play();
        }
    }
}
