using System.Linq;
using TaskTweens.CoroutineLoop;

namespace TaskTweens
{
	public static class LoopProvider
	{
		private static ILoopProvider sInstance;

		internal static ILoopProvider Instance
		{
			get
			{
				if (sInstance == null)
					sInstance = new CoroutineLoopProvider();
				return sInstance;
			}
		}

		public static void RegisterLoopProvider(ILoopProvider provider)
		{
			if (sInstance != null)
			{
				var loops = sInstance.GetAllLoops();
				sInstance.Stop();
				if (loops.Any())
					provider.AddLoops(loops);
			}
			sInstance = provider;
		}
	}
}