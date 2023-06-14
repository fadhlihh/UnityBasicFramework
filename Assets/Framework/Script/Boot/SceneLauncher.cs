using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Framework.Utility;

namespace Framework.Boot
{
    public abstract class SceneLauncher<TLauncher> : SingletonBehaviour<TLauncher> where TLauncher : SceneLauncher<TLauncher>
    {
        public virtual string SceneName { get; protected set; }

        private void Awake()
        {
            SceneStart();
            SceneLoader.Instance.LoadScene(SceneName);
        }

        protected abstract void SceneStart();
    }
}
