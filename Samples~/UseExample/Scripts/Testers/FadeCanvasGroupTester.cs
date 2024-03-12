using System.Threading;
using System.Threading.Tasks;
using TaskTweens;
using UnityEngine;

namespace Tests.Testers
{
	public class FadeCanvasGroupTester : Tester
	{
		[SerializeField] private CanvasGroup m_CanvasGroup;
		[SerializeField] private float m_From;
		[SerializeField] private float m_To;
		[SerializeField] private float m_LerpTime;

		protected override async Task TestInternal(CancellationToken token)
		{
			while (!token.IsCancellationRequested)
			{
				await m_CanvasGroup.Fade(m_From, m_To, m_LerpTime / 2, token);
				await m_CanvasGroup.Fade(m_To, m_From, m_LerpTime / 2, token);
			}
		}
	}
}