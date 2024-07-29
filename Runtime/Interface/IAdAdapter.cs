using System;

namespace com.ktgame.ads.core
{
    public interface IAdAdapter
    {
        IBannerAdapter Banner { get; }
        IInterstitialAdapter Interstitial { get; }
        IRewardVideoAdapter RewardVideo { get; }
        IAppOpenAdapter AppOpen { get; }
        void Initialize(Action<bool> onComplete);
        void SetPause(bool pause);
        void SetBanner(IBannerAdapter bannerAdapter);
        void SetInterstitial(IInterstitialAdapter interstitialAdapter);
        void SetRewardVideo(IRewardVideoAdapter rewardVideoAdapter);
        void SetAppOpen(IAppOpenAdapter appOpenAdapter);
    }
}