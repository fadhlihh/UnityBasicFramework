using Framework.Utility;

namespace Framework.Boot
{
    public abstract class Initializer : SingletonBehaviour<Initializer>
    {
        protected virtual string _initScene { get; set; }
        protected void Awake()
        {
            Init();
        }

        protected void Start()
        {
            SceneLoader.Instance.LoadScene(_initScene);
        }

        protected abstract void Init();
    }
}
