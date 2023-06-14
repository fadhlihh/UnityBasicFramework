using UnityEngine;
using Framework.Boot;

namespace Example
{
    public class MainMenuLauncher : SceneLauncher<MainMenuLauncher>
    {
        public override string SceneName => "MainMenu";
        protected override void SceneStart()
        {
            Debug.Log("Main Menu Start");
        }
    }
}
