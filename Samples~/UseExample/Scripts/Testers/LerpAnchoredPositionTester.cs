using System.Threading;
using System.Threading.Tasks;
using TaskTweens;
using UnityEngine;

namespace Tests.Testers
{
	public class LerpAnchoredPositionTester : Tester
	{
		[SerializeField] private RectTransform m_Point;
		[SerializeField] private RectTransform m_From;
		[SerializeField] private RectTransform m_To;
		[SerializeField] private AnimationCurve m_XCurve;
		[SerializeField] private AnimationCurve m_YCurve;
		[SerializeField] private float m_LerpTime;

		protected override async Task TestInternal(CancellationToken token)
		{
			while (!token.IsCancellationRequested)
			{
				await m_Point.LerpAnchoredPosition(m_From.anchoredPosition, m_To.anchoredPosition, m_XCurve, m_YCurve, m_LerpTime / 2, token);
				await m_Point.LerpAnchoredPosition(m_To.anchoredPosition, m_From.anchoredPosition, m_XCurve, m_YCurve, m_LerpTime / 2, token);
			}
		}
	}
}