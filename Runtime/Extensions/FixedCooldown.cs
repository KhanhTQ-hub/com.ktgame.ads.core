using System;
using System.Threading;
using Cysharp.Threading.Tasks;

namespace com.ktgame.ads.core.extensions
{
	public class FixedCooldown : IRequestStrategy
	{
		public event Action OnRequest;
        
		private bool _cooldown;
		private float _interval;
		private readonly CancellationTokenSource _cancelSource;

		public FixedCooldown(float interval)
		{
			_interval = interval;
			_cancelSource = new CancellationTokenSource();
		}
        
		public void SetInterval(float interval)
		{
			_interval = interval;
		}

		public void Request()
		{
			if (_cooldown)
			{
				return;
			}

			_cooldown = true;
			UniTask.Delay((int)(_interval * 1000), DelayType.DeltaTime, PlayerLoopTiming.Update, _cancelSource.Token).ContinueWith(OnNextRequest);
		}

		public void MarkSuccess()
		{
		}

		public void Cancel()
		{
			_cancelSource.Cancel();
		}

		private void OnNextRequest()
		{
			_cooldown = false;
			OnRequest?.Invoke();
		}
	}
}
