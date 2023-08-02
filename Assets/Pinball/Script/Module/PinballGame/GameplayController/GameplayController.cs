using UnityEngine;
using Framework.Entity;

namespace Pinball.Module.Gameplay
{
    public class GameplayController : Controller<GameplayData, IGameplayData>
    {
        [SerializeField]
        private Transform _ballSpawnLauncher;

        protected override void OnControllerAwake()
        {
            base.OnControllerAwake();
            _data.Position = _ballSpawnLauncher.position;
        }
    }
}
