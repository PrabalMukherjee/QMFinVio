using System;
using log4net;
using MongoDB.Driver.Core.Events;

namespace QMFinVioData.Instrument

{
	public class Log4NetEvents : IEventSubscriber
	{
		public static ILog CommandLog = LogManager.GetLogger("ApiCommand");
		private ReflectionEventSubscriber _subscriber;
		public Log4NetEvents()
		{
			_subscriber = new ReflectionEventSubscriber(this);
		}

		public bool TryGetEventHandler<TEvent>(out Action<TEvent> handler)
		{
			return _subscriber.TryGetEventHandler(out handler);
		}

		public void Handle(CommandStartedEvent ce)
		{
			CommandLog.Info(new {
				ce.Command,
				ce.CommandName,
				ce.ConnectionId,
				ce.OperationId,
				ce.RequestId
			});
		}

		public void Handle(CommandSucceededEvent ce)
		{
			CommandLog.Info(new
			{
				ce.CommandName,
				ce.ConnectionId,
				ce.OperationId,
				ce.RequestId,
				ce.Duration
			});

		}

		public void Handle(CommandFailedEvent ce)
		{
			CommandLog.Info(new
			{
				ce.CommandName,
				ce.ConnectionId,
				ce.OperationId,
				ce.RequestId,
				ce.Duration
			});

			CommandLog.Error(ce.Failure);

		}
	}
}