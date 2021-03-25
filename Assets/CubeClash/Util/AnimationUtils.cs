using DG.Tweening;
using UnityEngine;

namespace CubeClash.Scripts.Assembly.Util
{
    public static class AnimationUtils
    {
        public static Sequence ShrinkScale(this Transform transform, float strength = 1)
        {
            var fps = 57f;
            var tween = DOTween.Sequence();
            tween.Append(transform.DOScale(1 + 0.05f * strength, 8 / fps).SetEase(Ease.OutQuad));
            tween.Append(transform.DOScale(1f, 8 / fps).SetEase(Ease.OutQuad));

            var mainTween = DOTween.Sequence();
            mainTween.Append(transform.DOScale(1 + 0.1f * strength, 6 / fps).SetEase(Ease.OutQuad));
            mainTween.Append(transform.DOScale(1 - 0.075f * strength, 6 / fps).SetEase(Ease.OutQuad));
            mainTween.Append(tween);
            mainTween.AppendInterval(30 / fps);
            mainTween.SetLoops(-1);
            mainTween.SetUpdate(true);

            return mainTween;
        }
    }
}