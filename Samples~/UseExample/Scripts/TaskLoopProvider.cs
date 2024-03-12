using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TaskTweens;

namespace Tests
{
	public class TaskLoopProvider : ILoopProvider
	{
		private readonly TimeSpan mTickInterval;
		private readonly List<Loop> mLoops;
		private readonly CancellationTokenSource mCts;

		public TaskLoopProvider(float tickIntervalSeconds)
		{
			mTickInterval = TimeSpan.FromSeconds(tickIntervalSeconds);
			mLoops = new List<Loop>();
			mCts = new CancellationTokenSource();
			Run(mCts.Token).Forget();
		}

		private async Task Run(CancellationToken token)
		{
			while (!token.IsCancellationRequested)
			{
				for (var i = 0; i < mLoops.Count; i++)
				{
					var loop = mLoops[i];
					try
					{
						if (loop.Token.IsCancellationRequested)
						{
							loop.OnCancelled?.Invoke();
							RemoveLoop(loop);
							continue;
						}

						if (loop.CurrentTime >= loop.Time)
						{
							loop.OnFinished?.Invoke();
							RemoveLoop(loop);
							continue;
						}

						if (loop.CurrentTime == 0)
							loop.OnStart?.Invoke();

						loop.CurrentTime += (float)mTickInterval.TotalSeconds;
						loop.T = loop.CurrentTime / loop.Time;

						loop.OnUpdate?.Invoke(loop.T);

						mLoops[i] = loop;
					}
					catch (Exception e)
					{
						if (loop.OnException != null)
						{
							loop.OnException(e);
							RemoveLoop(mLoops[i]);
						}
						else
							throw;
					}

					void RemoveLoop(Loop loopToRemove)
					{
						mLoops.Remove(loopToRemove);
						i--;
					}
				}

				await Task.Delay(mTickInterval);
			}
		}

		public Loop[] GetAllLoops()
		{
			return mLoops.ToArray();
		}

		public void AddLoop(
			Action onStart,
			Action<float> onUpdate,
			Action onFinished,
			Action onCancelled,
			Action<Exception> onException,
			float time,
			CancellationToken token
		)
		{
			var loop = new Loop(
				onStart,
				onUpdate,
				onFinished,
				onCancelled,
				onException,
				time,
				token
			);

			mLoops.Add(loop);
		}

		public void AddLoop(Loop loop)
		{
			mLoops.Add(loop);
		}

		public void AddLoops(IEnumerable<Loop> loops)
		{
			mLoops.AddRange(loops);
		}

		public void Stop()
		{
			if (!mCts.IsCancellationRequested)
				mCts.Cancel();
		}
	}
}