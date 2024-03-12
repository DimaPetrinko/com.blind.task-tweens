using System.Threading;
using System.Threading.Tasks;
using TaskTweens;
using UnityEngine;

namespace Tests.Testers
{
	public class LerpScaleTester : Tester
	{
		[SerializeField] private Transform m_Object;
		[SerializeField] private float m_FromScale;
		[SerializeField] private float m_ToScale;
		[SerializeField] private float m_LerpTime;

		protected override async Task TestInternal(CancellationToken token)
		{
			while (!token.IsCancellationRequested)
			{
				await m_Object.LerpScale(m_FromScale, m_ToScale, m_LerpTime / 2, token);
				await m_Object.LerpScale(m_ToScale, m_FromScale, m_LerpTime / 2, token);
			}
		}
	}
}