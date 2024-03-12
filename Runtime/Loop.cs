using System;
using System.Threading;

namespace TaskTweens
{
	public struct Loop
	{
		public readonly Action OnStart;
		public readonly Action<float> OnUpdate;
		public readonly Action OnFinished;
		public readonly Action OnCancelled;
		public readonly Action<Exception> OnException;
		public readonly CancellationToken Token;
		public readonly float Time;
		public float CurrentTime;
		public float T;

		public Loop(Action onStart,
			Action<float> onUpdate,
			Action onFinished,
			Action onCancelled,
			Action<Exception> onException,
			float time,
			CancellationToken token
		)
		{
			OnStart = onStart;
			OnUpdate = onUpdate;
			OnFinished = onFinished;
			OnCancelled = onCancelled;
			OnException = onException;
			Time = time;
			Token = token;
			CurrentTime = 0;
			T = 0;
		}
	}
}