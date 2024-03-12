using System.Threading;
using System.Threading.Tasks;
using TaskTweens;
using UnityEngine;

namespace Tests.Testers
{
	public class LerpPositionTester : Tester
	{
		[SerializeField] private Transform m_Object;
		[SerializeField] private Transform m_FromPosition;
		[SerializeField] private Transform m_ToPosition;
		[SerializeField] private float m_LerpTime;

		protected override async Task TestInternal(CancellationToken token)
		{
			await m_Object.LerpPosition(m_FromPosition.position, m_ToPosition.position, m_LerpTime, token);
		}
	}
}