using SO;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
	[SerializeField] IntValue _obstacleCount;
	[SerializeField] GameObject _count2;
	[SerializeField] GameObject _count4;
	[SerializeField] GameObject _count6;

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
		switch (_obstacleCount.CurrentValue)
		{
			case 1:
				_count2.SetActive(true);
				_count4.SetActive(false);
				_count6.SetActive(false);
				break;
			case 2:
				_count2.SetActive(false);
				_count4.SetActive(true);
				_count6.SetActive(false);
				break;
			case 3:
				_count2.SetActive(false);
				_count4.SetActive(false);
				_count6.SetActive(true);
				break;
		}
	}
}