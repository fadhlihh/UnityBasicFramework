using UnityEngine;
using UnityEngine.SceneManagement;
using Framework.Utility;

namespace Framework.Boot
{
    public class SceneLoader : PersistentSingletonBehaviour<SceneLoader>
    {
        private string currentScene = string.Empty;
        public void LoadScene(string name)
        {
            if (!currentScene.Equals(name))
            {
                currentScene = name;
                SceneManager.LoadScene(name, LoadSceneMode.Single);
            }
            else
            {
                Debug.LogWarning($"{currentScene} scene is already loaded");
            }
        }

        public void ReloadScene()
        {
            SceneManager.LoadScene(currentScene, LoadSceneMode.Single);
        }

        public void LoadSceneAdditive(string name, bool isMainScene)
        {
            if (!currentScene.Equals(name))
            {
                SceneManager.LoadScene(name, LoadSceneMode.Additive);
                if (isMainScene)
                {
                    currentScene = name;
                }
            }
            else
            {
                Debug.LogWarning($"{name} scene is already loaded");
            }
        }

        public void UnloadScene(string name)
        {
            if (currentScene.Equals(name))
            {
                currentScene = string.Empty;
            }
            SceneManager.UnloadScene(name);
        }
    }
}
