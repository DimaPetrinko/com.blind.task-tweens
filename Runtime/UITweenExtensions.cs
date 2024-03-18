using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace TaskTweens
{
	public static class UITweenExtensions
	{
		public static Task Fade(
			this CanvasGroup canvasGroup,
			float from,
			float to,
			float time,
			CancellationToken token,
			bool exceptionOnCancel = false
		)
		{
			return TweenUtils.Tween(
				t => canvasGroup.alpha = Mathf.Lerp(from, to, t),
				time,
				token,
				() => canvasGroup.alpha = from,
				() => canvasGroup.alpha = to,
				exceptionOnCancel
			);
		}

		public static Task Fade(
			this CanvasGroup canvasGroup,
			float from,
			float to,
			AnimationCurve easingCurve,
			float time,
			CancellationToken token,
			bool exceptionOnCancel = false
		)
		{
			return TweenUtils.Tween(
				t => canvasGroup.alpha = Mathf.Lerp(from, to, easingCurve.Evaluate(t)),
				time,
				token,
				() => canvasGroup.alpha = from,
				() => canvasGroup.alpha = to,
				exceptionOnCancel
			);
		}

		public static Task Fade(
			this Image image,
			float from,
			float to,
			float time,
			CancellationToken token,
			bool exceptionOnCancel = false
		)
		{
			var color = image.color;
			color.a = from;
			var fromColor = color;
			color.a = to;
			var toColor = color;
			return TweenUtils.Tween(
				t =>
				{
					color.a = Mathf.Lerp(from, to, t);
					image.color = color;
				},
				time,
				token,
				() => image.color = fromColor,
				() => image.color = toColor,
				exceptionOnCancel
			);
		}

		public static Task Fade(
			this Image image,
			float from,
			float to,
			AnimationCurve easingCurve,
			float time,
			CancellationToken token,
			bool exceptionOnCancel = false
		)
		{
			var color = image.color;
			color.a = from;
			var fromColor = color;
			color.a = to;
			var toColor = color;
			return TweenUtils.Tween(
				t =>
				{
					color.a = Mathf.Lerp(from, to, easingCurve.Evaluate(t));
					image.color = color;
				},
				time,
				token,
				() => image.color = fromColor,
				() => image.color = toColor,
				exceptionOnCancel
			);
		}

		public static Task LerpColor(
			this Image image,
			Color from,
			Color to,
			float time,
			CancellationToken token,
			bool exceptionOnCancel = false
		)
		{
			return TweenUtils.Tween(
				t => image.color = Color.Lerp(from, to, t),
				time,
				token,
				() => image.color = from,
				() => image.color = to,
				exceptionOnCancel
			);
		}

		public static Task LerpColor(
			this Image image,
			Color from,
			Color to,
			AnimationCurve easingCurve,
			float time,
			CancellationToken token,
			bool exceptionOnCancel = false
		)
		{
			return TweenUtils.Tween(
				t => image.color = Color.LerpUnclamped(from, to, easingCurve.Evaluate(t)),
				time,
				token,
				() => image.color = from,
				() => image.color = to,
				exceptionOnCancel
			);
		}
	}
}