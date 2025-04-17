namespace com.ktgame.ads.core.extensions
{
	public class AutoRequestAppOpen : AppOpenDecorator
	{
		protected IRequestStrategy RequestStrategy { private set; get; }
		
		public AutoRequestAppOpen(IRequestStrategy requestStrategy, IAppOpenAdapter adapter) : base(adapter)
		{
			RequestStrategy = requestStrategy;
			RequestStrategy.OnRequest += Load;
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
