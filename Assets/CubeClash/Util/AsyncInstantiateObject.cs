using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubeClash.Scripts.Assembly.Util
{
    public static class AsyncInstantiateObject
    {
        public static void AsyncInstantiate<T>(this MonoBehaviour monoBehaviour, List<T> instantiateList, Action<T> asyncCallback, Action onComplete)
        {
            monoBehaviour.StartCoroutine(Instantiate(instantiateList, asyncCallback, onComplete));
        }

        public static void AsyncInstantiate<T>(this MonoBehaviour monoBehaviour, List<T> instantiateList, Action<int, T> asyncCallback, Action onComplete)
        {
            monoBehaviour.StartCoroutine(Instantiate(instantiateList, asyncCallback, onComplete));
        }

        private static IEnumerator Instantiate<T>(List<T> instantiateList, Action<T> asyncCallback, Action onComplete)
        {
            for (var i = 0; i < instantiateList.Count; i++)
            {
                asyncCallback?.Invoke(instantiateList[i]);
                if (i > 0 && i % 5 == 0)
                {
                    yield return 0;
                }
            }

            onComplete?.Invoke();
        }

        private static IEnumerator Instantiate<T>(List<T> instantiateList, Action<int, T> asyncCallback, Action onComplete)
        {
            for (var i = 0; i < instantiateList.Count; i++)
            {
                asyncCallback?.Invoke(i, instantiateList[i]);
                if (i > 0 && i % 5 == 0)
                {
                    yield return 0;
                }
            }

            onComplete?.Invoke();
        }
    }
}