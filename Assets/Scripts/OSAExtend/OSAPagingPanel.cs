using System.Collections.Generic;
using Com.TheFallenGames.OSA.Core;
using UnityEditor.PackageManager;
using UnityEngine;

namespace BadNorth.Scripts.UI.OSAExtend
{
    public abstract class OSAPagingPanel<TListAdapter, TData, TViewsHolder> : OSAListPanelBase<TListAdapter, TData, TViewsHolder>
        where TListAdapter : OSAListBase<TData, TViewsHolder>
        where TViewsHolder : BaseItemViewsHolder, new()
    {
        [SerializeField] protected CanvasGroup requestLoading;
        [SerializeField] protected CanvasGroup noResultTips;

        private bool isLoading;
        private int totalPage;

        /// <summary>
        /// init from 0
        /// request from 1
        /// </summary>
        protected int currentLoadPage;

        private List<TData> models;

        protected virtual bool InitForceRequest { get; set; }

        protected void Clear()
        {
            models.Clear();
            currentLoadPage = 0;
            SetNoResultActive(true);
        }

        public override void InitSetup()
        {
            base.InitSetup();

            currentLoadPage = 0;

            models = new List<TData>();

            SetNoResultActive(false);
        }

        public override void Init()
        {
            base.Init();

            InitRequest();
        }

        /// <summary>
        /// 强制拉到第一页
        /// </summary>
        public void ForceRequestToTop()
        {
            currentLoadPage = 0;
            DoRequest(currentLoadPage + 1, true);
        }

        private void InitRequest()
        {
            if (models.Count > 0)
            {
                // location
                listAdapter.ScrollTo(0);
            }

            currentLoadPage = 0;
            DoRequest(currentLoadPage + 1, InitForceRequest);
        }

        protected virtual void DoRequest(int page, bool isForceRefresh)
        {
            if (!isLoading)
            {
                isLoading = true;

                bool showLoading = models == null || models.Count <= 0;

                SetLoadingActive(showLoading);

                SetNoResultActive(false);

                RequestData(page, isForceRefresh);
            }
        }

        protected abstract void RequestData(int page, bool isForceRefresh);

        protected override bool AbleDoPullDownCallback()
        {
            return true;
        }

        protected override bool AbleDoPullUpCallback()
        {
            return !isLoading && currentLoadPage < totalPage;
        }

        protected override void OnPullDownReleased()
        {
            ForceRequestToTop();
        }

        protected override void OnPullUpRelease()
        {
            DoRequest(currentLoadPage + 1, false);
        }

        
        public virtual void OnRequestListDataError(StatusCode code, string msg)
        {
            isLoading = false;

            SetLoadingActive(false);

            // call adapter
            listAdapter.PullComplete();

            SetNoResultActive(models == null || models.Count <= 0);
        }

        private void SetLoadingActive(bool active)
        {
            if (requestLoading)
            {
                requestLoading.gameObject.SetActive(active);
            }
        }

        private void SetNoResultActive(bool active)
        {
            if (noResultTips)
            {
                return;
            }
        }
    }
}