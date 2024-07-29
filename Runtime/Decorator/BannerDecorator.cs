using System;

namespace com.ktgame.ads.core
{
    public class BannerDecorator : IBannerAdapter
    {
        protected IBannerAdapter Adapter { private set; get; }
        
        public event Action<AdError> OnLoadFailed;
        public event Action<AdPlacement> OnLoadSucceeded;
        public event Action<ImpressionData> OnImpressionSuccess;

        protected BannerDecorator(IBannerAdapter adapter)
        {
            Adapter = adapter;
            Adapter.OnLoadFailed += LoadFailedHandler;
            Adapter.OnLoadSucceeded += LoadSucceededHandler;
            Adapter.OnImpressionSuccess += ImpressionSuccessHandler;
        }

        protected virtual void ImpressionSuccessHandler(ImpressionData impressionData)
        {
            OnImpressionSuccess?.Invoke(impressionData);
        }

        protected virtual void LoadSucceededHandler(AdPlacement adPlacement)
        {
            OnLoadSucceeded?.Invoke(adPlacement);
        }

        protected virtual void LoadFailedHandler(AdError adError)
        {
            OnLoadFailed?.Invoke(adError);
        }

        public void Load()
        {
            Adapter.Load();
        }

        public void Show()
        {
            Adapter.Show();
        }

        public void Hide()
        {
           Adapter.Hide();
        }

        public void Destroy()
        {
            Adapter.Destroy();
        }
    }
}