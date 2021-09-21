using System;
using UnityEngine;

namespace SO
{
	[CreateAssetMenu(fileName = "Vehicle Spawn Manager Channel SO", menuName = "SO/Vehicle Spawn Manager Channel", order = 0)]
	public class VehicleSpawnManagerChannelSO : ScriptableObject
	{
		public Action<VehicleIdentity> VehicleSpawned;
	}
}
