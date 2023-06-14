using Framework.Entity;
using Example.Module.Block;

namespace Example.Module.Tile
{
    public class TileData : Data, ITileData
    {
        public int RowPosition { get; set; }
        public int ColumnPosition { get; set; }
        public BlockBase Block { get; set; }
    }
}
