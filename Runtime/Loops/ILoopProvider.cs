using System;
using System.Collections.Generic;
using System.Threading;

namespace TaskTweens.Loops
{
	public interface ILoopProvider
	{
		Loop[] GetAllLoops();
		void AddLoop(
			Action onStart,
			Action<float> onUpdate,
			Action onFinished,
			Action onCancelled,
			Action<Exception> onException,
			float time,
			CancellationToken token);
		void AddLoop(Loop loop);
		void AddLoops(IEnumerable<Loop> loops);
		void Stop();
	}
}