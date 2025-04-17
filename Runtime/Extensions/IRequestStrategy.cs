using System;

namespace com.ktgame.ads.core.extensions
{
	public interface IRequestStrategy
	{
		event Action OnRequest;
		void Request();
		void MarkSuccess();
		void Cancel();
	}
}
