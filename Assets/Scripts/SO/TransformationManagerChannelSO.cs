using System;
using UnityEngine;

namespace SO
{
	[CreateAssetMenu(fileName = "Transformation Manager Channel SO", menuName = "SO/Transformation Manager Channel", order = 0)]
	public class TransformationManagerChannelSO : ScriptableObject
	{
		public Action<GameObject> VehicleSpawning;
	}
}