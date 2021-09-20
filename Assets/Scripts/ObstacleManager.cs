using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
	[SerializeField] ObstacleManagerChannelSO _obstacleManagerChannelSO;

	void OnEnable()
	{
		_obstacleManagerChannelSO.ObstacleCountChanged += OnObstacleCountChanged;
		_obstacleManagerChannelSO.ObstacleHitSpeedChanged += OnObstacleHitSpeedChanged;
	}

	void OnDisable()
	{
		_obstacleManagerChannelSO.ObstacleCountChanged -= OnObstacleCountChanged;
		_obstacleManagerChannelSO.ObstacleHitSpeedChanged -= OnObstacleHitSpeedChanged;
	}

	void OnObstacleCountChanged(float val)
	{
		
	}

	void OnObstacleHitSpeedChanged(float val)
	{
		
	}
}