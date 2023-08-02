using UnityEngine;
using Framework.Entity;

namespace Pinball.Module.Gameplay
{
    public interface IGameplayData : IData
    {
        public Vector3 Position { get; }
    }
}
