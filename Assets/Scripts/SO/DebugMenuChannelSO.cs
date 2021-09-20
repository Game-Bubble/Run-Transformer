using System;
using UnityEngine;

namespace SO
{
	[CreateAssetMenu(fileName = "Debug Menu Channel SO", menuName = "SO/Debug Menu Channel", order = 0)]
	public class DebugMenuChannelSO : ScriptableObject
	{
		public Action<bool> DebugMenuActiveStateChanged;
	}
}
