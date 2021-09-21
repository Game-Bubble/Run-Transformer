using SO;
using UnityEngine;

public class AirMovementController : MonoBehaviour
{
	[SerializeField] Rigidbody _rigidbody;
	[SerializeField] MovementDataSO movementDataSO;
	[SerializeField] float _xMaxPos;
	
	float _lastFrameMousePosX;
	float _valueToApply;
	bool _didLastFrameClick;
	bool _shouldApplyForce;

	void Update()
	{
		if (Input.GetMouseButtonUp(0))
		{
			OnTouchPressUp();
		}

		if (Input.GetMouseButton(0))
		{
			OnTouchPress();
		}
	}

	void OnTouchPressUp()
	{
		_didLastFrameClick = false;
		_shouldApplyForce = false;
	}

	void OnTouchPress()
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
			_rigidbody.velocity = new Vector3(_valueToApply * movementDataSO.sideMoveSpeedMultiplier, _rigidbody.velocity.y, _rigidbody.velocity.z);
				
			Vector3 nextPos = _rigidbody.position;
			if (_rigidbody.position.x > _xMaxPos)
			{
				nextPos.x = _xMaxPos;
			}else if (_rigidbody.position.x < -_xMaxPos)
			{
				nextPos.x = -_xMaxPos;
			}
			_rigidbody.MovePosition(nextPos);
		}
	}
}