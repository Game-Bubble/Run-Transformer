using UnityEngine;

public class MovementController : MonoBehaviour
{
	[SerializeField] Rigidbody _rigidbody;
	[SerializeField] float _sideMoveSpeedMultiplier;
	[SerializeField] float _forwardMoveSpeed;

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
			
			_rigidbody.MovePosition(_rigidbody.position + new Vector3(_valueToApply * _sideMoveSpeedMultiplier, 0f, _forwardMoveSpeed) * Time.deltaTime);
		}
	}
}