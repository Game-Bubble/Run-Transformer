using SO;
using UnityEngine;

public class VehicleController : MonoBehaviour
{
	[SerializeField] MovementController _vehicleMovementController;
	[SerializeField] DrivingManagerChannelSO _drivingManagerChannelSO;
	[SerializeField] VehicleIdentity _vehicleIdentity;
	
	
	void OnEnable()
	{
		_drivingManagerChannelSO.TapFinished += OnTapFinished;
	}

	void OnDisable()
	{
		_drivingManagerChannelSO.TapFinished -= OnTapFinished;
	}

	void OnTapFinished()
	{
		_vehicleMovementController.enabled = true;
	}

	void Update()
	{
		if (Input.GetMouseButton(0))
		{
			_vehicleMovementController.OnTouchPress();

			foreach (ParticleSystem vehicleIdentityExhaust in _vehicleIdentity.Exhausts)
			{
				vehicleIdentityExhaust.Play(true);
			}
		}

		if (Input.GetMouseButtonUp(0))
		{
			_vehicleMovementController.OnTouchPressUp();
		}
	}
}