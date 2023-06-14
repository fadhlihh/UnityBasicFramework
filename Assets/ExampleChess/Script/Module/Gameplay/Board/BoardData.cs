using UnityEngine;
using Framework.Entity;

namespace Example.Module.Board
{
    public class BoardData : Data
    {
        public int Column { get; set; } = 9;
        public int Row { get; set; } = 6;
        public float Spacing { get; set; } = 140;
    }
}
