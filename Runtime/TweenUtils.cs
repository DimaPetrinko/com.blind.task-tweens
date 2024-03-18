using System;
using System.Threading;
using System.Threading.Tasks;
using TaskTweens.Loops;

namespace TaskTweens
{
	public static class TweenUtils
	{
		public static Task Tween(
			Action<float> onUpdate,
			float time,
			CancellationToken token,
			Action onStart = null,
			Action onFinish = null,
			bool exceptionOnCancel = false
		)
		{
			var tcs = new TaskCompletionSource<bool>();
			LoopProvider.Instance.AddLoop(
				onStart,
				onUpdate,
				() =>
				{
					onFinish?.Invoke();
					tcs.SetResult(true);
				},
				() =>
				{
					if (exceptionOnCancel)
						tcs.SetCanceled();
					else
						tcs.SetResult(false);
				},
				e => tcs.SetException(e),
				time,
				token
			);
			return tcs.Task;
		}
	}
}