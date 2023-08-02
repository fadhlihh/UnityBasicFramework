using System.Collections.Generic;
using Framework.Entity;
using Pinball.Module.Trap;

namespace Pinball.Module.TrapPool
{
    public class TrapPoolData : Data
    {
        public List<TrapController> Traps { get; set; } = new List<TrapController>();
        public int MaxTrapAmount { get; set; } = 3;
        public float SpawnDelay { get; set; } = 3f;
        public bool IsSpawning { get; set; } = false;
    }
}
