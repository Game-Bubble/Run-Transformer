using UnityEngine;

public class MovementController : MonoBehaviour
{
	[SerializeField] Rigidbody _rigidbody;
	[SerializeField] float _sideMoveSpeedMultiplier;
	[SerializeField] float _forwardMoveSpeedMultiplier;

	float _lastFrameMousePosX;
	float _valueToApply;
	bool _didLastFrameClick;
	bool _shouldApplyForce;
	
	void Update()
	{
		if (Input.GetMouseButton(0))
		{
			if (_didLastFrameClick)
			{
				// calculate diff between last frame and current
				float deltaPosX = Input.mousePosition.x - _lastFrameMousePosX;
				float normalizedDeltaPosX = Mathf.InverseLerp(1f, Screen.width * 0.02f, Mathf.Abs(deltaPosX));

				_valueToApply = deltaPosX > 0 ? normalizedDeltaPosX : -normalizedDeltaPosX;
				
				_shouldApplyForce = deltaPosX != 0f;
				
				_lastFrameMousePosX = Input.mousePosition.x;
			}
			else
			{
				_lastFrameMousePosX = Input.mousePosition.x;
				_didLastFrameClick = true;
			}
		}

		if (Input.GetMouseButtonUp(0))
		{
			_didLastFrameClick = false;
			_shouldApplyForce = false;
		}
	}

	void FixedUpdate()
	{
		if (_shouldApplyForce)
		{
			_rigidbody.AddForce(new Vector3(_valueToApply, 0f, 0f) * _sideMoveSpeedMultiplier * Time.deltaTime, ForceMode.VelocityChange);
		}
		else
		{
			_rigidbody.velocity = new Vector3(Mathf.Lerp(_rigidbody.velocity.x, 0f, Time.deltaTime * 5f), _rigidbody.velocity.y, _rigidbody.velocity.z);
		}
	}
}