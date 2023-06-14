using Framework.Entity;

namespace Example.Module.Block
{
    public class BlockData : Data, IBlockData
    {
        public BlockBase Block { get; set; }
        public BlockList BlockList { get; set; }
    }
}
