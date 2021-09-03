using System;
using System.Collections.Generic;
using System.Linq;
using Game.BuisnessLayer;
using Game.DataLayer;
using Game.Interfaces;

namespace Game
{
    class DiceGame : IDiceGame
    {
        IPlayerRepository playerRepository = new PlayerRepository();
        IScoreRepository scoreRepository = new ScoreRepository();
        Parser parser = new Parser();
        IScores scoreBL = new Scores();
        int noOfPlayers, targetValue, totalWinners = 0;
        Dictionary<int, int> scoreMap, turnSkip, prevValues;
        public void Initialize()
        {
            GetNoOfPlayersAndTargetScore();

            turnSkip = new Dictionary<int, int>();
            scoreMap = new Dictionary<int, int>();
            prevValues = new Dictionary<int, int>();

            for (int i = 0; i < noOfPlayers; i++) //initializing temp variables.
            {
                turnSkip.Add(i, 0);
                scoreMap.Add(i, 0);
                prevValues.Add(i, 0);
                playerRepository.AddPlayer(i);
                scoreRepository.AddScore(i, 0);
            }
            playerRepository.Randomise();
        }
        private void GetNoOfPlayersAndTargetScore()
        {
            Console.WriteLine("Enter the no of players: ");
            noOfPlayers = parser.ParseIntFromConsole();

            Console.WriteLine("Enter the Target Value: ");
            targetValue = parser.ParseIntFromConsole();

            Console.WriteLine("Press any key to start.");
            string input = Console.ReadLine().ToLower();
        }
        public void Play()
        {
            var playersList = playerRepository.GetPlayerList();
            int i = 0, remainingPlayers = noOfPlayers;
            while (remainingPlayers > 0)
            {
                i = i % remainingPlayers;
                int currentPlayer = playersList[i].Id;
                if (scoreMap[currentPlayer] < targetValue)
                {
                    ContinueGame(currentPlayer);
                }
                else
                {
                    playerRepository.RemovePlayer(currentPlayer);
                    remainingPlayers--;
                }
                i++;
            }
        }

        private void ContinueGame(int currentPlayer)
        {
            if (turnSkip[currentPlayer] > 0)
            {
                turnSkip[currentPlayer] = 0;
                return;
            }

            Console.WriteLine(string.Format("Player-{0}'s its your turn.\nPress Enter to Roll Dice", currentPlayer + 1));
            Console.ReadLine();
            RollDice(currentPlayer);
            scoreBL.PrintScoreTable(scoreRepository.GetScores());
        }
        public void RollDice(int currentPlayer)
        {

            int diceTop = RollDiceUtil(currentPlayer);

            if (diceTop == 6 && scoreMap[currentPlayer] < targetValue)
            {
                Console.WriteLine("You got another chance\n Press Enter to Roll Dice Again.");
                Console.ReadLine();
                RollDiceUtil(currentPlayer);
            }
        }
        public int RollDiceUtil(int currentPlayer)
        {
            var random = new Random();
            int diceTop = random.Next(1, 7);

            Console.WriteLine("Dice Shows: " + diceTop + "\n");

            scoreMap[currentPlayer] += diceTop;
            int rank = scoreMap[currentPlayer] >= targetValue ? ++totalWinners : 0;
            if (rank > 0)
            {
                Console.WriteLine("You have completed the game.Your rank is " + rank);
            }
            scoreRepository.UpdateScoreAndRank(currentPlayer, scoreMap[currentPlayer], rank);

            if (diceTop == 1 && prevValues[currentPlayer] == 1)
            {
                prevValues[currentPlayer] = 0;
                Console.WriteLine("Your next turn is skipped as you are very lucky :-)");
                turnSkip[currentPlayer] = 1;
            }
            else
            {
                prevValues[currentPlayer] = diceTop;
                turnSkip[currentPlayer] = 0;
            }
            return diceTop;
        }
    }
}