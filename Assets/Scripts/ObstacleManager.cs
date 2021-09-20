using SO;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
	[SerializeField] IntValue _obstacleCount;

	void OnEnable()
	{
		_obstacleCount.OnValueChanged += OnObstacleCountChanged;
	}

	void OnDisable()
	{
		_obstacleCount.OnValueChanged -= OnObstacleCountChanged;
	}

	void OnObstacleCountChanged()
	{
		
	}
}