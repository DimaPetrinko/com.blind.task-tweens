using System.Threading;
using System.Threading.Tasks;
using TaskTweens;
using UnityEngine;
using UnityEngine.UI;

namespace Tests.Testers
{
	public class FadeImageTester : Tester
	{
		[SerializeField] private Image m_Image;
		[SerializeField] private float m_From;
		[SerializeField] private float m_To;
		[SerializeField] private float m_LerpTime;

		protected override async Task TestInternal(CancellationToken token)
		{
			await m_Image.Fade(m_From, m_To, m_LerpTime, token);
		}
	}
}