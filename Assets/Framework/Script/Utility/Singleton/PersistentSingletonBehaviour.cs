using UnityEngine;

namespace Framework.Utility
{
    public class PersistentSingletonBehaviour<T> : MonoBehaviour where T : PersistentSingletonBehaviour<T>
    {
        private static T _instance;
        private static readonly object _padlock = new object();

        public static T Instance
        {
            get
            {
                lock (_padlock)
                {
                    if (_instance == null)
                    {
                        T t = FindObjectOfType<T>();
                        if (t != null)
                        {
                            _instance = t;
                        }
                        else
                        {
                            GameObject obj = new GameObject(typeof(T).Name);
                            _instance = obj.AddComponent<T>();
                            DontDestroyOnLoad(obj);
                        }
                    }
                    return _instance;
                }
            }
        }
    }
}
