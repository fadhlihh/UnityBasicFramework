using System.Collections.Generic;
using Framework.Entity;
using UnityEngine;
using UnityEngine.UI;

namespace Example.Module.Block
{
    public class BlockController : Controller<BlockData, IBlockData>
    {
        [SerializeField]
        private Image BlockImage;

        protected override void OnControllerStart()
        {
            base.OnControllerStart();
            _data.BlockList = Resources.Load<BlockList>("ScriptableObject/Block/BlockList");
            Debug.Log(_data.BlockList);
            SpawnNextBlock();
        }

        public void SpawnNextBlock()
        {
            int index = Random.Range(0, _data.BlockList.Blocks.Count);
            _data.Block = _data.BlockList.Blocks[index];
            BlockImage.sprite = _data.Block.Image;
        }
    }
}
