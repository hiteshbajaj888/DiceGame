using System.Collections.Generic;

namespace Game.Interfaces
{
    public interface IScoreRepository
    {
        void AddScore(int id, int value);
        void UpdateScoreAndRank(int id, int value, int rank);
        List<Score> GetScores();
    }
}