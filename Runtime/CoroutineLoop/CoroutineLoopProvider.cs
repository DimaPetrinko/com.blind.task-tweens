using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using Object = UnityEngine.Object;

namespace TaskTweens.CoroutineLoop
{
	internal class CoroutineLoopProvider : ILoopProvider
	{
		private readonly List<Loop> mLoops;
		private readonly CoroutineProxy mProxy;

		public CoroutineLoopProvider()
		{
			mProxy = new GameObject("CoroutineProxy").AddComponent<CoroutineProxy>();
			Object.DontDestroyOnLoad(mProxy.gameObject);

			mLoops = new List<Loop>();

			StartLooping();
		}

		private void StartLooping()
		{
			mProxy.StartCoroutine(Looping());
		}

		private IEnumerator Looping()
		{
			while (true)
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

						loop.CurrentTime += Time.deltaTime;
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
						mProxy.LoopsActive = mLoops.Count;
						i--;
					}
				}
				yield return null;
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
			var loop = new Loop(onStart, onUpdate, onFinished, onCancelled, onException, time, token);
			mLoops.Add(loop);
			mProxy.LoopsActive = mLoops.Count;
		}

		public void AddLoop(Loop loop)
		{
			mLoops.Add(loop);
			mProxy.LoopsActive = mLoops.Count;
		}

		public void AddLoops(IEnumerable<Loop> loops)
		{
			mLoops.AddRange(loops);
			mProxy.LoopsActive = mLoops.Count;
		}

		public void Stop()
		{
			mProxy.StopAllCoroutines();
		}
	}
}