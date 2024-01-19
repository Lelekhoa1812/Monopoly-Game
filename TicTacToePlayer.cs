using SplashKitSDK;
using System;

namespace MonopolyGame
{
    public class TicTacToePlayer
    {
        public PlayerType Type { get; }

        public TicTacToePlayer(PlayerType type)
        {
            Type = type;
        }
    }
}
