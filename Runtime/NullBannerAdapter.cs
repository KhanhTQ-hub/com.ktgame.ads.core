using System;

namespace com.ktgame.ads.core
{
    public class NullBannerAdapter : IBannerAdapter
    {
        public static readonly NullBannerAdapter Instance = new NullBannerAdapter();

        public event Action<AdError> OnLoadFailed;
        public event Action<AdPlacement> OnLoadSucceeded;
        public event Action<ImpressionData> OnImpressionSuccess;

        private NullBannerAdapter()
        {
        }

        public void Load()
        {
        }

        public void Show()
        {
        }

        public void Hide()
        {
        }

        public void Destroy()
        {
        }
    }
}
