using UnityEngine;
using Framework.Entity;

namespace Pinball.Module.Gameplay
{
    public class GameplayData : Data, IGameplayData
    {
        public Vector3 Position { get; set; }
    }
}
