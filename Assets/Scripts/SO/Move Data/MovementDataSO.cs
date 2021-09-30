using UnityEngine;

namespace SO.Move_Data
{
	[CreateAssetMenu(fileName = "Movement Data", menuName = "SO/Player Data", order = 0)]
	public class MovementDataSO : ScriptableObject
	{
		public float sideMoveSpeedMultiplier = 10f;
		public float forwardMoveSpeed = 4f;
		public float throwPower = 40f;
		
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
