using System;
using System.Threading;
using Cysharp.Threading.Tasks;

namespace com.ktgame.ads.core.extensions
{
	public class ExponentialCooldown : IRequestStrategy
	{
		public event Action OnRequest;

		private bool _cooldown;
		private int _maxRetryAttempt;
		private int _baseValue;
		private int _retryAttempt;
		private readonly CancellationTokenSource _cancelSource;

		public ExponentialCooldown(int maxRetryAttempt, int baseValue)
		{
			_maxRetryAttempt = maxRetryAttempt;
			_baseValue = baseValue;
			_cancelSource = new CancellationTokenSource();
		}

		public void SetBaseValue(int baseValue)
		{
			_baseValue = baseValue;
		}

		public void SetMaxRetryAttempt(int maxRetryAttempt)
		{
			_maxRetryAttempt = maxRetryAttempt;
		}

		public void Request()
		{
			if (_cooldown) return;

			_cooldown = true;
			_retryAttempt++;
			var retryDelay = (int)Math.Pow(_baseValue, Math.Min(_maxRetryAttempt, _retryAttempt)) * 1000;
			UniTask.Delay(retryDelay, DelayType.DeltaTime, PlayerLoopTiming.Update, _cancelSource.Token)
				.ContinueWith(OnNextRequest);
		}

		public void MarkSuccess()
		{
			_retryAttempt = 0;
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
