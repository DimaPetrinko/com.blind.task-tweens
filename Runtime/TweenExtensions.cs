using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace TaskTweens
{
	public static class TweenExtensions
	{
		public static Task LerpPosition(
			this Transform transform,
			Vector3 from,
			Vector3 to,
			float time,
			CancellationToken token,
			bool exceptionOnCancel = false
		)
		{
			return Tween(
				t => transform.position = Vector3.Lerp(from, to, t),
				time,
				token,
				() => transform.position = from,
				() => transform.position = to,
				exceptionOnCancel
			);
		}

		public static Task LerpPosition(
			this Transform transform,
			Vector3 from,
			Vector3 to,
			AnimationCurve easingCurve,
			float time,
			CancellationToken token,
			bool exceptionOnCancel = false
		)
		{
			return Tween(
				t => transform.position = Vector3.LerpUnclamped(from, to, easingCurve.Evaluate(t)),
				time,
				token,
				() => transform.position = from,
				() => transform.position = to,
				exceptionOnCancel
			);
		}

		public static Task LerpRotation(
			this Transform transform,
			Quaternion from,
			Quaternion to,
			float time,
			CancellationToken token,
			bool exceptionOnCancel = false
		)
		{
			return Tween(
				t => transform.rotation = Quaternion.Slerp(from, to, t),
				time,
				token,
				() => transform.rotation = from,
				() => transform.rotation = to,
				exceptionOnCancel
			);
		}

		public static Task LerpRotation(
			this Transform transform,
			Quaternion from,
			Quaternion to,
			AnimationCurve easingCurve,
			float time,
			CancellationToken token,
			bool exceptionOnCancel = false
		)
		{
			return Tween(
				t => transform.rotation = Quaternion.SlerpUnclamped(from, to, easingCurve.Evaluate(t)),
				time,
				token,
				() => transform.rotation = from,
				() => transform.rotation = to,
				exceptionOnCancel
			);
		}

		public static Task LerpRotation(
			this Transform transform,
			Vector3 fromEuler,
			Vector3 toEuler,
			float time,
			CancellationToken token,
			bool exceptionOnCancel = false
		)
		{
			var from = Quaternion.Euler(fromEuler);
			var to = Quaternion.Euler(toEuler);

			return Tween(
				t => transform.rotation = Quaternion.Slerp(from, to, t),
				time,
				token,
				() => transform.rotation = from,
				() => transform.rotation = to,
				exceptionOnCancel
			);
		}

		public static Task LerpRotation(
			this Transform transform,
			Vector3 fromEuler,
			Vector3 toEuler,
			AnimationCurve easingCurve,
			float time,
			CancellationToken token,
			bool exceptionOnCancel = false
		)
		{
			var from = Quaternion.Euler(fromEuler);
			var to = Quaternion.Euler(toEuler);

			return Tween(
				t => transform.rotation = Quaternion.SlerpUnclamped(from, to, easingCurve.Evaluate(t)),
				time,
				token,
				() => transform.rotation = from,
				() => transform.rotation = to,
				exceptionOnCancel
			);
		}

		public static Task LerpRotationAroundAxis(
			this Transform transform,
			Vector3 axis,
			float fromAngle,
			float toAngle,
			float time,
			CancellationToken token,
			bool exceptionOnCancel = false
		)
		{
			return Tween(
				t =>
				{
					var angle = Mathf.Lerp(fromAngle, toAngle, t);
					transform.rotation = Quaternion.AngleAxis(angle, axis);
				},
				time,
				token,
				() => transform.rotation = Quaternion.AngleAxis(fromAngle, axis),
				() => transform.rotation = Quaternion.AngleAxis(toAngle, axis),
				exceptionOnCancel
			);
		}

		public static Task LerpRotationAroundAxis(
			this Transform transform,
			Vector3 axis,
			float fromAngle,
			float toAngle,
			AnimationCurve easingCurve,
			float time,
			CancellationToken token,
			bool exceptionOnCancel = false
		)
		{
			return Tween(
				t =>
				{
					var angle = Mathf.LerpUnclamped(fromAngle, toAngle, easingCurve.Evaluate(t));
					transform.rotation = Quaternion.AngleAxis(angle, axis);
				},
				time,
				token,
				() => transform.rotation = Quaternion.AngleAxis(fromAngle, axis),
				() => transform.rotation = Quaternion.AngleAxis(toAngle, axis),
				exceptionOnCancel
			);
		}

		public static Task LerpScale(
			this Transform transform,
			float fromScale,
			float toScale,
			float time,
			CancellationToken token,
			bool exceptionOnCancel = false
		)
		{
			var from = new Vector3(fromScale, fromScale, fromScale);
			var to = new Vector3(toScale, toScale, toScale);

			return transform.LerpScale(from, to, time, token, exceptionOnCancel);
		}

		public static Task LerpScale(
			this Transform transform,
			float fromScale,
			float toScale,
			AnimationCurve easingCurve,
			float time,
			CancellationToken token,
			bool exceptionOnCancel = false
		)
		{
			var from = new Vector3(fromScale, fromScale, fromScale);
			var to = new Vector3(toScale, toScale, toScale);

			return transform.LerpScale(from, to, easingCurve, time, token, exceptionOnCancel);
		}

		public static Task LerpScale(
			this Transform transform,
			Vector3 fromScale,
			Vector3 toScale,
			float time,
			CancellationToken token,
			bool exceptionOnCancel = false
		)
		{
			return Tween(
				t => transform.localScale = Vector3.Lerp(fromScale, toScale, t),
				time,
				token,
				() => transform.localScale = fromScale,
				() => transform.localScale = toScale,
				exceptionOnCancel
			);
		}

		public static Task LerpScale(
			this Transform transform,
			Vector3 fromScale,
			Vector3 toScale,
			AnimationCurve easingCurve,
			float time,
			CancellationToken token,
			bool exceptionOnCancel = false
		)
		{
			return Tween(
				t => transform.localScale = Vector3.LerpUnclamped(fromScale, toScale, easingCurve.Evaluate(t)),
				time,
				token,
				() => transform.localScale = fromScale,
				() => transform.localScale = toScale,
				exceptionOnCancel
			);
		}

		public static Task Fade(
			this CanvasGroup canvasGroup,
			float from,
			float to,
			float time,
			CancellationToken token,
			bool exceptionOnCancel = false
		)
		{
			return Tween(
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
			return Tween(
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
			return Tween(
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
			return Tween(
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
			return Tween(
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
			return Tween(
				t => image.color = Color.LerpUnclamped(from, to, easingCurve.Evaluate(t)),
				time,
				token,
				() => image.color = from,
				() => image.color = to,
				exceptionOnCancel
			);
		}

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
			return Tween(
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
			return Tween(
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
			return Tween(
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
			return Tween(
				t => sprite.color = Color.LerpUnclamped(from, to, easingCurve.Evaluate(t)),
				time,
				token,
				() => sprite.color = from,
				() => sprite.color = to,
				exceptionOnCancel
			);
		}

		public static Task Fade(
			this AudioSource audioSource,
			float from,
			float to,
			float time,
			CancellationToken token,
			bool exceptionOnCancel = false
		)
		{
			return Tween(
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
			return Tween(
				t => audioSource.volume = Mathf.Lerp(from, to, easingCurve.Evaluate(t)),
				time,
				token,
				() => audioSource.volume = from,
				() => audioSource.volume = to,
				exceptionOnCancel
			);
		}

		private static Task Tween(
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