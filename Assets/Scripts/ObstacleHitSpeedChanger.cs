using SO;
using UnityEngine;
using UnityEngine.Playables;

public class ObstacleHitSpeedChanger : MonoBehaviour
{
	[SerializeField] PlayableDirector _playableDirector;
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
		print("SADASD");
		float value = _obstacleHitSpeed.CurrentValue / 2f;
		_playableDirector.playableGraph.GetRootPlayable(0).SetSpeed(value);
	}
}