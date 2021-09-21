using System;
using UnityEngine;

namespace SO
{
	[CreateAssetMenu(fileName = "Driving Manager Channel SO", menuName = "SO/Driving Manager Channel", order = 0)]
	public class DrivingManagerChannelSO : ScriptableObject
	{
		public Action TapFinished;
	}
}
