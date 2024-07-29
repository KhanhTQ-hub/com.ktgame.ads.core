using System;

namespace com.ktgame.ads.core
{
    public class NullAppOpenAdapter : IAppOpenAdapter
    {
        public static readonly NullAppOpenAdapter Instance = new NullAppOpenAdapter();

        private NullAppOpenAdapter()
        {
            
        }
        
        public event Action<AdError> OnLoadFailed;
        public event Action OnLoadSucceeded;
        public event Action<AdError> OnShowFailed;
        public event Action<AdPlacement> OnShowSucceeded;
        public event Action<AdPlacement> OnClicked;
        public event Action OnClosed;
        public event Action<ImpressionData> OnImpressionSuccess;
        public event Action<AppState> OnAppStateChanged;
        public bool IsReady { set; get; }
        
        public void Load()
        {
            OnLoadSucceeded?.Invoke();
        }

        public void Show()
        {
            OnClosed?.Invoke();
        }
    }
}
