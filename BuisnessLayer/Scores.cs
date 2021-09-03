using System;
using System.Collections.Generic;
using System.Linq;
using Game.DataLayer;
using Game.Interfaces;

namespace Game.BuisnessLayer
{
    public class Scores : IScores
    {
        public void PrintScoreTable(List<Score> scoreSet)
        {
            // Heap can be used to store scores. to reduce complexity to O(log(n)) instead of sorting every time.SortedSet in C# can be used.
            scoreSet = SortDescending(scoreSet);

            Console.WriteLine("Score Table:");
            int rank = 0;
            foreach (var i in scoreSet)
            {
                //add dictionary check
                Console.WriteLine(string.Format("Rank-{2} | Player-{0} | Score-{1}", i.PlayerId + 1, i.Value, ++rank));
            }
            Console.WriteLine();
        }


        private List<Score> SortDescending(List<Score> scores)
        {
            var compare = new ScoreCompare();
            scores = scores.OrderByDescending(p => p, compare).ToList();
            return scores;
        }
    }
}