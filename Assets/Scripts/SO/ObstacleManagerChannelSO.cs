using UnityEngine;

namespace SO
{
	[CreateAssetMenu(fileName = "Obstacle Manager Channel SO", menuName = "SO/Obstacle Manager Channel", order = 0)]
	public class ObstacleManagerChannelSO : ScriptableObject
	{
		[SerializeField] IntValue _obstacleHitSpeed;
		[SerializeField] IntValue _obstacleCount;
	
		public void SetObstacleHitSpeed(float val)
		{
			_obstacleHitSpeed.CurrentValue = Mathf.RoundToInt(val);
		}

		public void SetObstacleCount(float val)
		{
			_obstacleCount.CurrentValue = Mathf.RoundToInt(val);
		}
	}
}