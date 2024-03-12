using System.Threading;
using System.Threading.Tasks;
using TaskTweens;
using UnityEngine;

namespace Tests.Testers
{
	public class LerpRotationTester : Tester
	{
		[SerializeField] private Transform m_Object;
		[SerializeField] private Transform m_FromRotation;
		[SerializeField] private Transform m_ToRotation;
		[SerializeField] private float m_LerpTime;

		protected override async Task TestInternal(CancellationToken token)
		{
			await m_Object.LerpRotation(m_FromRotation.rotation, m_ToRotation.rotation, m_LerpTime, token);
		}
	}
}