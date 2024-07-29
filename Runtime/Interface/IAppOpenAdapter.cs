using System;

namespace com.ktgame.ads.core
{
    public interface IAppOpenAdapter
    {
        event Action<AdError> OnLoadFailed;
        event Action OnLoadSucceeded;
        event Action<AdError> OnShowFailed;
        event Action<AdPlacement> OnShowSucceeded;
        event Action<AdPlacement> OnClicked;
        event Action OnClosed;
        event Action<ImpressionData> OnImpressionSuccess;
        event Action<AppState> OnAppStateChanged;
        bool IsReady { get; }
        
        void Load();
        void Show();
    }
}
