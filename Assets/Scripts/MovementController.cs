using SO;
using SO.Move_Data;
using UnityEngine;

public class MovementController : MonoBehaviour
{
	[SerializeField] Rigidbody _rigidbody;
	[SerializeField] MovementDataSO movementDataSO;
	[SerializeField] GameConstraints _gameConstraints;
	
	public float ThrowPower => movementDataSO.throwPower;

	float _lastFrameMousePosX;
	float _valueToApply;
	bool _didLastFrameClick;
	bool _shouldApplyForce;

	public void OnTouchPressUp()
	{
		_didLastFrameClick = false;
		_shouldApplyForce = false;
	}

	public void OnTouchPress()
	{
		if (_didLastFrameClick)
		{
			// calculate diff between last frame and current
			float deltaPosX = Input.mousePosition.x - _lastFrameMousePosX;
			float normalizedDeltaPosX = Mathf.InverseLerp(1f, Screen.width * 0.02f, Mathf.Abs(deltaPosX));

			_valueToApply = deltaPosX > 0 ? normalizedDeltaPosX : -normalizedDeltaPosX;

			_shouldApplyForce = true;

			_lastFrameMousePosX = Input.mousePosition.x;
		}
		else
		{
			_lastFrameMousePosX = Input.mousePosition.x;
			_didLastFrameClick = true;
		}
	}

	void FixedUpdate()
	{
		if (_shouldApplyForce)
		{
			Vector3 nextPos = _rigidbody.position + new Vector3(_valueToApply * movementDataSO.sideMoveSpeedMultiplier, 0f, movementDataSO.forwardMoveSpeed) * Time.deltaTime;
			if (nextPos.x > _gameConstraints.playerMaxXPos)
			{
				nextPos.x = _gameConstraints.playerMaxXPos;
			}else if (nextPos.x < -_gameConstraints.playerMaxXPos)
			{
				nextPos.x = -_gameConstraints.playerMaxXPos;
			}
			_rigidbody.MovePosition(nextPos);
		}
	}
}