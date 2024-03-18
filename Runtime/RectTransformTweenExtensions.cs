using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace TaskTweens
{
	public static class RectTransformTweenExtensions
	{
		public static Task LerpAnchoredPosition(
			this RectTransform rectTransform,
			Vector2 from,
			Vector2 to,
			float time,
			CancellationToken token,
			bool exceptionOnCancel = false
		)
		{
			return TweenUtils.Tween(
				t => rectTransform.anchoredPosition = Vector2.LerpUnclamped(from, to, t),
				time,
				token,
				() => rectTransform.anchoredPosition = from,
				() => rectTransform.anchoredPosition = to,
				exceptionOnCancel
			);
		}

		public static Task LerpAnchoredPosition(
			this RectTransform rectTransform,
			Vector2 from,
			Vector2 to,
			AnimationCurve easingCurve,
			float time,
			CancellationToken token,
			bool exceptionOnCancel = false
		)
		{
			return TweenUtils.Tween(
				t => rectTransform.anchoredPosition = Vector2.LerpUnclamped(from, to, easingCurve.Evaluate(t)),
				time,
				token,
				() => rectTransform.anchoredPosition = from,
				() => rectTransform.anchoredPosition = to,
				exceptionOnCancel
			);
		}

		public static Task LerpAnchoredPosition(
			this RectTransform rectTransform,
			Vector2 from,
			Vector2 to,
			AnimationCurve positionXCurve,
			AnimationCurve positionYCurve,
			float time,
			CancellationToken token,
			bool exceptionOnCancel = false
		)
		{
			return TweenUtils.Tween(
				t =>
				{
					var x = Mathf.LerpUnclamped(from.x, to.x, positionXCurve.Evaluate(t));
					var y = Mathf.LerpUnclamped(from.y, to.y, positionYCurve.Evaluate(t));
					rectTransform.anchoredPosition = new Vector2(x, y);
				},
				time,
				token,
				() => rectTransform.anchoredPosition = from,
				() => rectTransform.anchoredPosition = to,
				exceptionOnCancel
			);
		}

		public static Task LerpPivot(
			this RectTransform rectTransform,
			Vector2 from,
			Vector2 to,
			float time,
			CancellationToken token,
			bool exceptionOnCancel = false
		)
		{
			return TweenUtils.Tween(
				t => rectTransform.pivot = Vector2.LerpUnclamped(from, to, t),
				time,
				token,
				() => rectTransform.pivot = from,
				() => rectTransform.pivot = to,
				exceptionOnCancel
			);
		}

		public static Task LerpPivot(
			this RectTransform rectTransform,
			Vector2 from,
			Vector2 to,
			AnimationCurve easingCurve,
			float time,
			CancellationToken token,
			bool exceptionOnCancel = false
		)
		{
			return TweenUtils.Tween(
				t => rectTransform.pivot = Vector2.LerpUnclamped(from, to, easingCurve.Evaluate(t)),
				time,
				token,
				() => rectTransform.pivot = from,
				() => rectTransform.pivot = to,
				exceptionOnCancel
			);
		}

		public static Task LerpSizeDelta(
			this RectTransform rectTransform,
			Vector2 from,
			Vector2 to,
			float time,
			CancellationToken token,
			bool exceptionOnCancel = false
		)
		{
			return TweenUtils.Tween(
				t => rectTransform.sizeDelta = Vector2.LerpUnclamped(from, to, t),
				time,
				token,
				() => rectTransform.sizeDelta = from,
				() => rectTransform.sizeDelta = to,
				exceptionOnCancel
			);
		}

		public static Task LerpSizeDelta(
			this RectTransform rectTransform,
			Vector2 from,
			Vector2 to,
			AnimationCurve easingCurve,
			float time,
			CancellationToken token,
			bool exceptionOnCancel = false
		)
		{
			return TweenUtils.Tween(
				t => rectTransform.sizeDelta = Vector2.LerpUnclamped(from, to, easingCurve.Evaluate(t)),
				time,
				token,
				() => rectTransform.sizeDelta = from,
				() => rectTransform.sizeDelta = to,
				exceptionOnCancel
			);
		}
	}
}