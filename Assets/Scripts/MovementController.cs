using UnityEngine;

public class MovementController : MonoBehaviour
{
	[SerializeField] Rigidbody _rigidbody;
	[SerializeField] float _movementSpeedMultiplier;

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
				// 1125 pixel, 3meter platform wideness
				// 375 pixel for 1m
				
				// calculate diff between last frame and current
				float deltaPosX = Input.mousePosition.x - _lastFrameMousePosX;
				float normalizedDeltaPosX = Mathf.InverseLerp(0f, Screen.width / 3f, Mathf.Abs(deltaPosX));
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
			_rigidbody.AddForce(new Vector3(_valueToApply, 0f, 0f) * _movementSpeedMultiplier * Time.deltaTime, ForceMode.VelocityChange);
		}
		else
		{
			_rigidbody.velocity = new Vector3(0f, _rigidbody.velocity.y, _rigidbody.velocity.z);
		}
	}
}