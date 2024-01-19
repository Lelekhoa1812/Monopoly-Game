using System;

namespace MonopolyGame
{
    public class Dice
    {
        private Random _random;
        public int DiceValue1 { get; private set; }
        public int DiceValue2 { get; private set; }

        public Dice()
        {
            _random = new Random();
            DiceValue1 = 0;
            DiceValue2 = 0;
        }

        public void RollDice()
        {
            DiceValue1 = _random.Next(1, 7);
            DiceValue2 = _random.Next(1, 7);
        }

        // Reset dice value after turn
        public void ResetDiceValues()
        {
            DiceValue1 = 0;
            DiceValue2 = 0;
        }

        // Side game Rock Paper Scissor
        public void RPS(bool r, bool p, bool s)
        {
            int rps = _random.Next(1, 4);
            // Machine play rock
            if (rps == 1)
            {
                if (r)
                {
                    Console.WriteLine("It's a draw, you both play rock.");
                }
                if (p)
                {
                    Console.WriteLine("You win, paper wraps rock.");
                }
                if (s)
                {
                    Console.WriteLine("You lose, scissor is broken by rock.");
                }
            }
            // Machine play paper
            if (rps == 2)
            {
                if (r)
                {
                    Console.WriteLine("You lose, rock is wrapped by paper.");
                }
                if (p)
                {
                    Console.WriteLine("It's a draw, you both play paper.");
                }
                if (s)
                {
                    Console.WriteLine("You win, scissor cuts paper.");
                }
            }
            // Machine play scissor
            if (rps == 3)
            {
                if (r)
                {
                    Console.WriteLine("You win, rock breaks scissor.");
                }
                if (p)
                {
                    Console.WriteLine("You lose, paper is cut by scissor.");
                }
                if (s)
                {
                    Console.WriteLine("It's a draw, you both play scissor.");
                }
            }
        }
    }
}
