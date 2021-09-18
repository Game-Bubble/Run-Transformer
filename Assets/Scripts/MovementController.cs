using UnityEngine;

public class MovementController : MonoBehaviour
{
	[SerializeField] float _sideMoveSpeedMultiplier;
	[SerializeField] float _forwardMoveSpeed;

	float _lastFrameMousePosX;
	float _valueToApply;
	bool _didLastFrameClick;
	
	public void OnTouchPressUp()
	{
		_didLastFrameClick = false;
	}

	public void OnTouchPress()
	{
		if (_didLastFrameClick)
		{
			// calculate diff between last frame and current
			float deltaPosX = Input.mousePosition.x - _lastFrameMousePosX;
			float normalizedDeltaPosX = Mathf.InverseLerp(1f, Screen.width * 0.02f, Mathf.Abs(deltaPosX));

			_valueToApply = deltaPosX > 0 ? normalizedDeltaPosX : -normalizedDeltaPosX;
			
			_lastFrameMousePosX = Input.mousePosition.x;
			
			transform.Translate(_valueToApply * _sideMoveSpeedMultiplier * Time.deltaTime, 0f, _forwardMoveSpeed * Time.deltaTime);
		}
		else
		{
			_lastFrameMousePosX = Input.mousePosition.x;
			_didLastFrameClick = true;
		}
	}
}