using CubeClash.Scripts.Assembly.Util;
using UnityEngine;
using UnityEngine.Events;

namespace WorldMap.Scripts.Utils
{
    public class ColliderButton : MonoBehaviour
    {
        [SerializeField] private bool IgnoreUIClick;
        [SerializeField] private UnityEvent m_onClick = new UnityEvent();

        private void OnMouseDown()
        {
            if (IgnoreUIClick || !UnityUtil.IsPointerOverGameObject())
            {
                m_onClick.Invoke();
            }
        }
    }
}