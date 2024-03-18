using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace TaskTweens
{
	public static class AudioTweenExtensions
	{
		public static Task Fade(
			this AudioSource audioSource,
			float from,
			float to,
			float time,
			CancellationToken token,
			bool exceptionOnCancel = false
		)
		{
			return TweenUtils.Tween(
				t => audioSource.volume = Mathf.Lerp(from, to, t),
				time,
				token,
				() => audioSource.volume = from,
				() => audioSource.volume = to,
				exceptionOnCancel
			);
		}

		public static Task Fade(
			this AudioSource audioSource,
			float from,
			float to,
			AnimationCurve easingCurve,
			float time,
			CancellationToken token,
			bool exceptionOnCancel = false
		)
		{
			return TweenUtils.Tween(
				t => audioSource.volume = Mathf.Lerp(from, to, easingCurve.Evaluate(t)),
				time,
				token,
				() => audioSource.volume = from,
				() => audioSource.volume = to,
				exceptionOnCancel
			);
		}
	}
}