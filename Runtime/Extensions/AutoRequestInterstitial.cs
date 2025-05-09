﻿namespace com.ktgame.ads.core.extensions
{
	public class AutoRequestInterstitial : InterstitialDecorator
	
	{
		protected IRequestStrategy RequestStrategy { private set; get; }

		public AutoRequestInterstitial(IRequestStrategy requestStrategy, IInterstitialAdapter adapter) : base(adapter)
		{
			RequestStrategy = requestStrategy;
			RequestStrategy.OnRequest += RequestHandler;
		}

		private void RequestHandler()
		{
			Load();
		}

		protected override void LoadSucceededHandler()
		{
			base.LoadSucceededHandler();
			RequestStrategy.MarkSuccess();
		}

		protected override void LoadFailedHandler(AdError error)
		{
			base.LoadFailedHandler(error);
			RequestStrategy.Request();
		}

		protected override void ShowFailedHandler(AdError error)
		{
			base.ShowFailedHandler(error);
			Load();
		}

		protected override void ClosedHandler()
		{
			base.ClosedHandler();
			Load();
		}
	}
}
