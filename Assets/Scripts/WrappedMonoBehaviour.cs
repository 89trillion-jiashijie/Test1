using UnityEngine;

namespace Script.Util
{
    public class WrappedMonoBehaviour : MonoBehaviour
    {
        protected Transform cachedTransform;

        public Transform Transform
        {
            get
            {
                if (!cachedTransform)
                {
                    cachedTransform = transform;
                }

                return cachedTransform;
            }
        }

        protected GameObject cachedObject;

        public GameObject GameObject
        {
            get
            {
                if (!cachedObject)
                {
                    cachedObject = gameObject;
                }

                return cachedObject;
            }
        }
    }
}