using UnityEngine;
using UnityEngine.UI;

namespace CubeClash.Scripts.Assembly.Util
{
    /// <summary>
    /// TODO Unfinished
    /// Handle Horizontal Content
    /// </summary>
    public class ContentAdapter : MonoBehaviour
    {
        [SerializeField] private VerticalLayoutGroup verticalLayout;
        [SerializeField] private RectTransform content;

        private Rect itemRect;

        public void AdjustContent(int itemCount, RectTransform contentItemPrefab)
        {
            itemRect = contentItemPrefab.rect;
            verticalLayout.enabled = false;

            RectOffset padding = verticalLayout.padding;
            float adjustHeight = padding.top + padding.bottom;
            float itemHeight = itemRect.height;

            adjustHeight += itemCount * itemHeight + verticalLayout.spacing * itemCount - 1;
            content.sizeDelta = new Vector2(content.sizeDelta.x, adjustHeight);
        }

        public Vector2 CalculateItemAnchoredPosition(int index)
        {
            float height = itemRect.height;

            float y = verticalLayout.padding.top + height * 0.5f + index * (height + verticalLayout.spacing);

            // TODO handle direction
            return new Vector2(0, -y);
        }

        public int CalculateItemIndex(float offsetY)
        {
            float height = itemRect.height;

            int index = (int) ((offsetY - height * 0.5f - verticalLayout.padding.top) / (verticalLayout.spacing + height));

            return index;
        }
    }
}