using System.Collections.Generic;

namespace Game.Interfaces
{
    public interface IPlayerRepository
    {
        void AddPlayer(int id);
        void RemovePlayer(int id);
        List<Player> GetPlayerList();
        void Randomise();
    }
}