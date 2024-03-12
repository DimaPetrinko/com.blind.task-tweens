using System.Threading;
using System.Threading.Tasks;
using TaskTweens;
using UnityEngine;

namespace Tests.Testers
{
	public class LerpRotationAxisTester : Tester
	{
		[SerializeField] private Transform m_Object;
		[SerializeField] private float m_FromAngle;
		[SerializeField] private float m_ToAngle;
		[SerializeField] private float m_LerpTime;

		protected override async Task TestInternal(CancellationToken token)
		{
			while (!token.IsCancellationRequested)
			{
				await m_Object.LerpRotationAroundAxis(Vector3.up, m_FromAngle, m_ToAngle, m_LerpTime, token);
			}
		}
	}
}