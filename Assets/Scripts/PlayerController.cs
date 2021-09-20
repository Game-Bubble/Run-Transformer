using SO;
using UnityEngine;

[RequireComponent(typeof(MovementController), typeof(AnimationController))]
public class PlayerController : MonoBehaviour
{
	[SerializeField] MovementController _movementController;
	[SerializeField] AnimationController _animationController;

	[SerializeField] DebugMenuChannelSO _debugMenuChannelSO;
	
	void Update()
	{
		if (Input.GetMouseButton(0))
		{
			_movementController.OnTouchPress();
			_animationController.PlayRunAnimation(true);
		}

		if (Input.GetMouseButtonUp(0))
		{
			_movementController.OnTouchPressUp();
			_animationController.PlayRunAnimation(false);
		}
	}

	void OnEnable()
	{
		_debugMenuChannelSO.DebugMenuActiveStateChanged += OnDebugMenuActiveStateChanged;
	}

	void OnDisable()
	{
		_debugMenuChannelSO.DebugMenuActiveStateChanged -= OnDebugMenuActiveStateChanged;
	}
	
	void OnDebugMenuActiveStateChanged(bool val)
	{
		_movementController.enabled = !val;
	}
}