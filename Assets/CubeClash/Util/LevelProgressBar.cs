using System;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace CubeClash.Scripts.Assembly.UI
{
    public class LevelProgressBar : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI lvText;
        [SerializeField] private TextMeshProUGUI progressText;
        [SerializeField] public WrappedSlider progressSlider;

        private int uiLevel;
        private int uiProgress;
        private Sequence mainTween;

        private readonly List<Tweener> tweeners = new List<Tweener>();

        /// <summary>
        /// -1 is full
        /// </summary>
        public int maxProgress { get; private set; }

        /// <summary>
        /// lv, progress, max, display text
        /// </summary>
        public Func<int, int, int, string> updateProgressFunction;

        public Action upgradeAction;

        public void Setup(int level, int progress, int maxProgress)
        {
            uiLevel = level;
            uiProgress = progress;
            this.maxProgress = maxProgress;

            UpdateUIContent(uiLevel, uiProgress);
        }

        public void SetMaxValue(int max)
        {
            this.maxProgress = max;
        }

        public void SetToMaxState(int maxLv)
        {
            progressText.text = "Max";
            progressSlider.Value = 1;
            lvText.text = maxLv.ToString();
        }

        public void SetEmptyState()
        {
            progressText.text = "-/-";
            progressSlider.Value = 0;
            lvText.text = "-";
        }

        public void UpdateUIWithAnimation(int level, int progress, Action onComplete)
        {
            mainTween = DOTween.Sequence();

            bool isUpgraded = level > uiLevel;
            int start = isUpgraded ? 0 : uiProgress;
            start = level < uiLevel ? maxProgress : start;

            if (isUpgraded)
            {
                mainTween.Append(UpdateUIAnimation(uiLevel, uiProgress, maxProgress));
                mainTween.AppendCallback(() => { upgradeAction?.Invoke(); });
            }

            mainTween.Append(UpdateUIAnimation(level, start, progress));
            mainTween.OnComplete(() =>
            {
                tweeners.Clear();
                SyncUiProgress(level, progress);
                UpdateUIContent(level, progress);
                onComplete?.Invoke();
            });
        }

        private void SyncUiProgress(int level, int progress)
        {
            uiLevel = level;
            uiProgress = progress;
        }

        private void UpdateUIContent(int lv, int progress)
        {
            if (lvText)
            {
                lvText.text = $"{lv}";
            }

            progressText.text = updateProgressFunction?.Invoke(lv, progress, maxProgress) ?? $"{progress}/{maxProgress}";
            progressSlider.Value = maxProgress == -1 ? 1 : progress * 1f / maxProgress;
        }

        private Tween UpdateUIAnimation(int lv, int start, int to)
        {
            float duration = maxProgress == -1 ? 0.5f : Mathf.Abs(to - start) * 1f / maxProgress * progressSlider.MaxSize * 0.0025f;
            var tween = DOTween.To(x => { UpdateUIContent(lv, Mathf.RoundToInt(x)); }, start,
                to, duration).SetEase(Ease.InSine);
            tweeners.Add(tween);
            return tween;
        }

        private void OnDestroy()
        {
            tweeners.ForEach(item => item?.Kill());
            tweeners.Clear();
            mainTween?.Kill();
        }
    }
}