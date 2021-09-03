using System;
using System.Collections.Generic;

namespace Game
{
    public class ScoreCompare : IComparer<Score>
    {
        public int Compare(Score one, Score two)
        {
            if (one.Rank < 1 || two.Rank < 1)
            {
                return one.Value.CompareTo(two.Value);
            }
            return two.Rank.CompareTo(one.Rank);
        }
    }
}