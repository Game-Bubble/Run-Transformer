using DG.Tweening;
using SO;
using UnityEngine;

public class ObstacleHitSpeedChanger : MonoBehaviour
{
	[SerializeField] DOTweenAnimation _doTweenAnimation;
	[SerializeField] IntValue _obstacleHitSpeed;

	void OnEnable()
	{
		_obstacleHitSpeed.OnValueChanged += OnObstacleHitSpeedChanged;
	}

	void OnDisable()
	{
		_obstacleHitSpeed.OnValueChanged -= OnObstacleHitSpeedChanged;
	}

	void OnObstacleHitSpeedChanged()
	{
		float value = _obstacleHitSpeed.CurrentValue / 2f;
		_doTweenAnimation.duration = value;
	}
}