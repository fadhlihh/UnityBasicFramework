using System.Collections.Generic;
using Framework.Entity;
using Pinball.Module.Coin;

namespace Pinball.Module.CoinPool
{
    public class CoinPoolData : Data
    {
        public List<CoinController> Coins { get; set; } = new List<CoinController>();
        public int MaxCoinAmount { get; set; } = 3;
        public float SpawnDelay { get; set; } = 3f;
        public bool IsSpawning { get; set; } = false;
    }
}
