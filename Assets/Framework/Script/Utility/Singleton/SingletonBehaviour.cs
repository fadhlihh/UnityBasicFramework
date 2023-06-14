using UnityEngine;

namespace Framework.Utility
{
    public class SingletonBehaviour<T> : MonoBehaviour where T : SingletonBehaviour<T>
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
                        }
                    }
                    return _instance;
                }
            }
        }
    }
}
