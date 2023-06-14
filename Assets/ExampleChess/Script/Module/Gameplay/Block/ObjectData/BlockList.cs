using System.Collections.Generic;
using UnityEngine;

namespace Example.Module.Block
{
    [CreateAssetMenu(fileName = "Dragon", menuName = "Block/BlockList", order = 0)]
    public class BlockList : ScriptableObject
    {
        public List<BlockBase> Blocks = new List<BlockBase>();
    }
}
