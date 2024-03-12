using UnityEngine;

namespace TaskTweens.CoroutineLoop
{
	internal class CoroutineProxy : MonoBehaviour
	{
		[field: SerializeField] public int LoopsActive { get; set; }
	}
}