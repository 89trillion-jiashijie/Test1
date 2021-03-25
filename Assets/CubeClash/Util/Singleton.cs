using UnityEngine;

namespace CubeClash
{
    public class Singleton<T> where T : Singleton<T>, new()
    {
        public static T Instance { get; } = new T();
    }

    public class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
    {
        public static T Instance { get; private set; }

        protected virtual void Awake()
        {
            Instance = this as T;
        }
    }
}