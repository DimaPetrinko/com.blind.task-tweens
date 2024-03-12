using System.Threading;
using System.Threading.Tasks;
using TaskTweens;
using UnityEngine;

namespace Tests.Testers
{
	public class FadeSpriteTester : Tester
	{
		[SerializeField] private SpriteRenderer m_Image;
		[SerializeField] private float m_From;
		[SerializeField] private float m_To;
		[SerializeField] private float m_LerpTime;

		protected override async Task TestInternal(CancellationToken token)
		{
			while (!token.IsCancellationRequested)
			{
				await m_Image.Fade(m_From, m_To, m_LerpTime / 2, token);
				await m_Image.Fade(m_To, m_From, m_LerpTime / 2, token);
			}
		}
	}
}