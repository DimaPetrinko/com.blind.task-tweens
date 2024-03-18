using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace TaskTweens
{
	public static class TransformTweenExtensions
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
			return TweenUtils.Tween(
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
			return TweenUtils.Tween(
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
			return TweenUtils.Tween(
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
			return TweenUtils.Tween(
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

			return TweenUtils.Tween(
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

			return TweenUtils.Tween(
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
			return TweenUtils.Tween(
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
			return TweenUtils.Tween(
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
			return TweenUtils.Tween(
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
			return TweenUtils.Tween(
				t => transform.localScale = Vector3.LerpUnclamped(fromScale, toScale, easingCurve.Evaluate(t)),
				time,
				token,
				() => transform.localScale = fromScale,
				() => transform.localScale = toScale,
				exceptionOnCancel
			);
		}
	}
}