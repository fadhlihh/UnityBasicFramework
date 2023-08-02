using UnityEngine;
using Framework.Boot;
using Pinball.Module.Gameplay;
using Pinball.Module.Launcher;
using Pinball.Module.LauncherExit;
using Pinball.Module.Ball;
using Pinball.Module.Paddle;
using Pinball.Module.Bumper;
using Pinball.Module.SwitchPool;

namespace Pinball.Scene
{
    public class PinballGameLauncher : SceneLauncher<PinballGameLauncher>
    {
        public override string SceneName => "PinballGame";

        [SerializeField]
        public GameplayController Gameplay;
        [SerializeField]
        public LauncherController Launcher;
        [SerializeField]
        public LauncherExitController LauncherExit;
        [SerializeField]
        public BallController Ball;
        [SerializeField]
        public SwitchPoolController SwitchPool;

        protected override void SceneStart()
        {

        }
    }
}
