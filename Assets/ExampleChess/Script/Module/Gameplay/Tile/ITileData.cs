using Framework.Entity;
using Example.Module.Block;

namespace Example.Module.Tile
{
    public interface ITileData : IData
    {
        public BlockBase Block { get; set; }
    }
}
