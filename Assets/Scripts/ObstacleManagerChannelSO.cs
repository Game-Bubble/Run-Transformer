using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Obstacle Manager Channel SO", menuName = "SO/Obstacle Manager Channel", order = 0)]
public class ObstacleManagerChannelSO : ScriptableObject
{
	public event Action<float> ObstacleHitSpeedChanged;
	public event Action<float> ObstacleCountChanged;
	
	public void SetObstacleHitSpeed(float val)
	{
		ObstacleHitSpeedChanged?.Invoke(val);
	}

	public void SetObstacleCount(float val)
	{
		ObstacleCountChanged?.Invoke(val);
	}
}