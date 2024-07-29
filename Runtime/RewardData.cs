namespace com.ktgame.ads.core
{
    public class RewardData
    {
        public readonly string RewardId;
        public readonly AdPlacement AdPlacement;

        public RewardData(string rewardId, AdPlacement adPlacement)
        {
            RewardId = rewardId;
            AdPlacement = adPlacement;
        }
    }
}