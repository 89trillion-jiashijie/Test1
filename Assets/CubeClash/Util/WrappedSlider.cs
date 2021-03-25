using UnityEngine;

public class WrappedSlider : MonoBehaviour
{
    public enum SliderType
    {
        Horizontal,
        Vertical
    }

    [Header("Fill progress")] public RectTransform boundTransform;
    public RectTransform bgRectTransform;
    public RectTransform rectMask;

    public SliderType sliderType = SliderType.Horizontal;

    private Rect originSize;
    private bool isInit;
    private float value;

    public float MaxSize
    {
        get
        {
            if (!isInit)
            {
                Init();
            }

            return sliderType == SliderType.Horizontal ? originSize.width : originSize.height;
        }
        set
        {
            if (sliderType == SliderType.Horizontal)
            {
                boundTransform.sizeDelta = new Vector2(value, boundTransform.rect.height);
            }
            else if (sliderType == SliderType.Vertical)
            {
                boundTransform.sizeDelta = new Vector2(boundTransform.rect.width, value);
            }

            if (bgRectTransform)
            {
                bgRectTransform.sizeDelta = boundTransform.sizeDelta;
            }

            Init();
        }
    }

    private void Init()
    {
        isInit = true;
        originSize = boundTransform.rect;
    }

    public float Value
    {
        get => value;
        set
        {
            if (!isInit)
            {
                Init();
            }

            this.value = value;

            if (sliderType == SliderType.Horizontal)
            {
                var currentWidth = originSize.width * value;
                rectMask.sizeDelta = new Vector2(currentWidth, originSize.height);
            }
            else if (sliderType == SliderType.Vertical)
            {
                var currentHeight = originSize.height * value;
                rectMask.sizeDelta = new Vector2(originSize.width, currentHeight);
            }
        }
    }

    public float Offset
    {
        set
        {
            if (!isInit)
            {
                Init();
            }

            if (sliderType == SliderType.Horizontal)
            {
                rectMask.sizeDelta = new Vector2(0, value);
            }
            else if (sliderType == SliderType.Vertical)
            {
                rectMask.anchoredPosition = new Vector2(0, value);
            }
        }
    }
}