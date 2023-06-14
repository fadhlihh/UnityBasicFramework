using System.Collections.Generic;
using UnityEngine;

namespace Example.Module.Block
{
    public abstract class BlockBase : ScriptableObject
    {
        public int Score;
        public Sprite Image;
        public List<AttackZone> AttackZone = new List<AttackZone>();

        public abstract void SetAttackZone(int rowPosition, int columnPosition, int columnCount, int rowCount);
    }
}
