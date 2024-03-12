using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace Tests.Testers
{
	public abstract class Tester : MonoBehaviour
	{
		private CancellationTokenSource mCts;

		public async Task TestAsync()
		{
			Cancel();
			mCts = new CancellationTokenSource();

			await TestInternal(mCts.Token);
		}

		protected abstract Task TestInternal(CancellationToken token);

		public void Cancel()
		{
			if (mCts != null)
			{
				mCts.Cancel();
				mCts.Dispose();
				mCts = null;
			}
		}

		private void OnDestroy()
		{
			Cancel();
		}
	}
}