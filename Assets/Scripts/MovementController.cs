using UnityEngine;

public class MovementController : MonoBehaviour
{
	[SerializeField] Rigidbody _rigidbody;
	[SerializeField] float _sideMoveSpeedMultiplier;
	[SerializeField] float _forwardMoveSpeed;
	[SerializeField] float _maxForwardMoveSpeed;

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
			float normalizedDeltaPosX = Mathf.InverseLerp(1f, Screen.width * 0.01f, Mathf.Abs(deltaPosX));

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
			_rigidbody.AddForce(new Vector3(_valueToApply * _sideMoveSpeedMultiplier, 0f, _forwardMoveSpeed) * Time.deltaTime, ForceMode.VelocityChange);
			if (_rigidbody.velocity.z >= _maxForwardMoveSpeed)
			{
				_rigidbody.velocity = new Vector3(_rigidbody.velocity.x, _rigidbody.velocity.y, _maxForwardMoveSpeed);
			}
		}
		else
		{
			_rigidbody.velocity = new Vector3(Mathf.Lerp(_rigidbody.velocity.x, 0f, Time.deltaTime * 5f), _rigidbody.velocity.y, Mathf.Lerp(_rigidbody.velocity.z, 0f, Time.deltaTime * 5f));
			if (_rigidbody.velocity.magnitude < 0.3f)
			{
				_rigidbody.velocity = Vector3.zero;
			}
		}
	}
}