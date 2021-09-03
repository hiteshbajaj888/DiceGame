using System;
using System.Collections.Generic;
using Game.Interfaces;

namespace Game.DataLayer
{
    public class ScoreRepository : IScoreRepository
    {
        public List<Score> Scores { get; set; } = new List<Score>();

        public void AddScore(int id, int value)
        {
            Scores.Add(new Score
            {
                PlayerId = id,
                Value = value
            });
        }
        public void UpdateScoreAndRank(int id, int value, int rank)
        {
            var obj = Scores.Find(p => p.PlayerId == id);
            obj.Value = value;
            obj.Rank = rank;
        }
        public List<Score> GetScores()
        {
            return Scores;
        }

    }
}