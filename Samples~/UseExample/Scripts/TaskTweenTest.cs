using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskTweens;
using TaskTweens.Loops;
using Tests.Testers;
using UnityEngine;

namespace Tests
{
	public class TaskTweenTest : MonoBehaviour
	{
		[SerializeField] private Tester[] m_Testers;

		private Dictionary<KeyCode, Tester> mTesters;

		private void Awake()
		{
			LoopProvider.RegisterLoopProvider(new TaskLoopProvider(1 / 60f));

			mTesters = new Dictionary<KeyCode, Tester>();
			for (var i = 0; i < m_Testers.Length; i++)
			{
				KeyCode key;
				if (i <= 8)
				{
					key = KeyCode.Alpha1 + i;
				}
				else if (i == 9)
				{
					key = KeyCode.Alpha0;
				}
				else
				{
					key = KeyCode.Keypad0 + i - 10;
				}

				mTesters.Add(key, m_Testers[i]);
			}

			var log = mTesters
				.Select(p => $"{p.Key} - {p.Value.name}")
				.Aggregate((a, b) => $"{a}\n{b}");
			Debug.Log(log);
		}

		private void Update()
		{
			foreach (var pair in mTesters)
			{
				if (Input.GetKeyDown(pair.Key))
				{
					pair.Value.TestAsync().Forget();
				}
			}

			if (Input.GetKeyDown(KeyCode.Space))
			{
				RunAll().Forget();
			}

			if (Input.GetKeyDown(KeyCode.Escape))
			{
				foreach (var tester in mTesters.Values)
					tester.Cancel();
			}
		}

		private async Task RunAll()
		{
			foreach (var t in mTesters.Values)
			{
				await Task.WhenAny(
					Task.Delay(TimeSpan.FromSeconds(2)),
					t.TestAsync()
				);
				t.Cancel();
			}
		}
	}
}