using Framework.Entity;

namespace Example.Module.Block
{
    public interface IBlockData : IData
    {
        public BlockBase Block { get; }
        public BlockList BlockList { get; set; }
    }
}
