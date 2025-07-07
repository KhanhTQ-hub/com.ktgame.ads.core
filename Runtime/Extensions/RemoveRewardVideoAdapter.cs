using System;
using com.ktgame.ads.core;
using UnityEngine;

namespace com.ktgame.ads.core.extensions
{
	[Serializable]
	public class RemoveRewardVideoAdapter : RewardVideoDecorator
	{
		[SerializeField] private bool _adRemoved;

		public RemoveRewardVideoAdapter(IRewardVideoAdapter adapter, bool adRemoved) : base(adapter)
		{
			_adRemoved = adRemoved;
		}

		public void SetAdRemoved(bool adRemoved)
		{
			_adRemoved = adRemoved;
		}

		public override void Show(AdPlacement adPlacement)
		{
			if (_adRemoved)
			{
				RewardHandler(adPlacement);
			}
			else
			{
				base.Show(adPlacement);
			}
		}
	}
}
