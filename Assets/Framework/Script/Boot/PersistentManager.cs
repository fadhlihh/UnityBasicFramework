using Framework.Utility;

namespace Framework.Boot
{
    public abstract class PersistentManager<TPersistenManager> : SingletonBehaviour<TPersistenManager> where TPersistenManager : PersistentManager<TPersistenManager>
    {
        public GameInstanceBase GameInstance;

        protected void Awake()
        {
            DontDestroyOnLoad(this);
        }
    }
}
