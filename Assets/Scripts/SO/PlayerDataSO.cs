using System;
using UnityEngine;

namespace SO
{
	[CreateAssetMenu(fileName = "Player Data SO", menuName = "SO/Player Data", order = 0)]
	public class PlayerDataSO : ScriptableObject
	{
		public float sideMoveSpeedMultiplier = 10f;
		public float forwardMoveSpeed = 4f;

		public void ChangeSideMoveSpeedMultiplier(float val)
		{
			sideMoveSpeedMultiplier = val;
		}
		
		public void ChangeForwardMoveSpeedMultiplier(float val)
		{
			forwardMoveSpeed = val;
		}
	}
}
