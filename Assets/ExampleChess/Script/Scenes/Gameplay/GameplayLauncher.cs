using UnityEngine;
using Framework.Boot;
using Example.Module.Gameplay;
using Example.Module.Board;
using Example.Module.Block;
using Example.Module.Timer;
using Example.Module.Score;

namespace Example.Scene
{
    public class GameplayLauncher : SceneLauncher<GameplayLauncher>
    {
        public override string SceneName => "Gameplay";

        [SerializeField]
        public GameplayController Gameplay;
        [SerializeField]
        public BoardController Board;
        [SerializeField]
        public BlockController Block;
        [SerializeField]
        public TimerController Timer;
        [SerializeField]
        public ScoreController Score;

        protected override void SceneStart()
        {
            Debug.Log("Gameplay Start");
        }
    }
}
