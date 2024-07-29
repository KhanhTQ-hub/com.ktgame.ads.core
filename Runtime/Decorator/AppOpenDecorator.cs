using System;
namespace com.ktgame.ads.core
{
    public class AppOpenDecorator : IAppOpenAdapter
    {
        protected IAppOpenAdapter Adapter { private set; get; }
        
        public event Action<AdError> OnLoadFailed;
        public event Action OnLoadSucceeded;
        public event Action<AdError> OnShowFailed;
        public event Action<AdPlacement> OnShowSucceeded;
        public event Action<AdPlacement> OnClicked;
        public event Action OnClosed;
        public event Action<ImpressionData> OnImpressionSuccess;
        public event Action<AppState> OnAppStateChanged;
        public bool IsReady => Adapter.IsReady;

        protected AppOpenDecorator(IAppOpenAdapter adapter)
        {
            Adapter = adapter;
            Adapter.OnLoadFailed += LoadFailedHandler;
            Adapter.OnShowFailed += ShowFailedHandler;
            Adapter.OnShowSucceeded += ShowSucceededHandler;
            Adapter.OnClicked += ClickHandler;
            Adapter.OnImpressionSuccess += ImpressionSuccessHandler;
            Adapter.OnLoadSucceeded += LoadSucceededHandler;
            Adapter.OnClosed += ClosedHandler;
            Adapter.OnAppStateChanged += AppStateChangedHandler;
        }

        private void ClickHandler(AdPlacement adPlacement)

        {
            OnClicked?.Invoke(adPlacement);
        }

        protected virtual void ClosedHandler()
        {
            OnClosed?.Invoke();
        }

        protected virtual void LoadSucceededHandler()
        {
            OnLoadSucceeded?.Invoke();
        }

        protected virtual void ImpressionSuccessHandler(ImpressionData impressionData)
        {
            OnImpressionSuccess?.Invoke(impressionData);
        }

        protected virtual void ShowSucceededHandler(AdPlacement placement)
        {
            OnShowSucceeded?.Invoke(placement);
        }

        protected virtual void ShowFailedHandler(AdError error)
        {
            OnShowFailed?.Invoke(error);
        }

        protected virtual void LoadFailedHandler(AdError error)
        {
            OnLoadFailed?.Invoke(error);
        }

        protected virtual void AppStateChangedHandler(AppState state)
        {
            OnAppStateChanged?.Invoke(state);
        }
        
        public void Load()
        {
           Adapter.Load();
        }

        public void Show()
        {
           Adapter.Show();
        }
    }
}
