using System;
using System.Collections.Generic;
using System.Linq;
using Game.Interfaces;

namespace Game.DataLayer
{
    public class PlayerRepository : IPlayerRepository
    {
        public List<Player> Players { get; set; } = new List<Player>();

        public void AddPlayer(int id)
        {
            Players.Add(new Player
            {
                Id = id,
                Name = string.Format("Player-{0}", id + 1)
            });
        }
        public void RemovePlayer(int id)
        {
            Players.RemoveAll(p => p.Id == id);
        }
        public List<Player> GetPlayerList()
        {
            return Players;
        }
        public void Randomise()
        {
            // Random Players Order Set
            Random rnd = new Random();
            Players = Players.OrderBy(v => rnd.Next()).ToList();
        }
    }
}