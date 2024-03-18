using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace TaskTweens
{
	public static class SpriteTweenExtensions
	{
		public static Task Fade(
			this SpriteRenderer sprite,
			float from,
			float to,
			float time,
			CancellationToken token,
			bool exceptionOnCancel = false
		)
		{
			var color = sprite.color;
			color.a = from;
			var fromColor = color;
			color.a = to;
			var toColor = color;
			return TweenUtils.Tween(
				t =>
				{
					color.a = Mathf.Lerp(from, to, t);
					sprite.color = color;
				},
				time,
				token,
				() => sprite.color = fromColor,
				() => sprite.color = toColor,
				exceptionOnCancel
			);
		}

		public static Task Fade(
			this SpriteRenderer sprite,
			float from,
			float to,
			AnimationCurve easingCurve,
			float time,
			CancellationToken token,
			bool exceptionOnCancel = false
		)
		{
			var color = sprite.color;
			color.a = from;
			var fromColor = color;
			color.a = to;
			var toColor = color;
			return TweenUtils.Tween(
				t =>
				{
					color.a = Mathf.Lerp(from, to, easingCurve.Evaluate(t));
					sprite.color = color;
				},
				time,
				token,
				() => sprite.color = fromColor,
				() => sprite.color = toColor,
				exceptionOnCancel
			);
		}

		public static Task LerpColor(
			this SpriteRenderer sprite,
			Color from,
			Color to,
			float time,
			CancellationToken token,
			bool exceptionOnCancel = false
		)
		{
			return TweenUtils.Tween(
				t => sprite.color = Color.Lerp(from, to, t),
				time,
				token,
				() => sprite.color = from,
				() => sprite.color = to,
				exceptionOnCancel
			);
		}

		public static Task LerpColor(
			this SpriteRenderer sprite,
			Color from,
			Color to,
			AnimationCurve easingCurve,
			float time,
			CancellationToken token,
			bool exceptionOnCancel = false
		)
		{
			return TweenUtils.Tween(
				t => sprite.color = Color.LerpUnclamped(from, to, easingCurve.Evaluate(t)),
				time,
				token,
				() => sprite.color = from,
				() => sprite.color = to,
				exceptionOnCancel
			);
		}
	}
}