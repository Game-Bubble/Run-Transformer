using MoreMountains.Feedbacks;
using MoreMountains.NiceVibrations;
using SO;
using UnityEngine;

public class TapController : MonoBehaviour
{
	[SerializeField] CameraManagerChannelSO _cameraManagerChannelSO;
	[SerializeField] VehicleSpawnManagerChannelSO _vehicleSpawnManagerChannelSO;
	[SerializeField] MMFeedbacks _tapFeedbacks;
	[SerializeField] IntValue _tapValue;

	MMFeedbackWiggle _mmFeedbackWiggle;
	MMFeedbackParticles[] _mmFeedbackParticles;
	
	void OnEnable()
	{
		_vehicleSpawnManagerChannelSO.VehicleSpawned += OnVehicleSpawned;
		_mmFeedbackWiggle = _tapFeedbacks.GetComponent<MMFeedbackWiggle>();
		_mmFeedbackParticles = _tapFeedbacks.GetComponents<MMFeedbackParticles>();
	}

	void OnDisable()
	{
		_vehicleSpawnManagerChannelSO.VehicleSpawned -= OnVehicleSpawned;
	}

	void OnVehicleSpawned(VehicleIdentity vehicleIdentity)
	{
		_cameraManagerChannelSO.SendTapCameraActiveSignal();
		
		_mmFeedbackWiggle.TargetWiggle = vehicleIdentity.MmWiggle;
		_mmFeedbackParticles[0].BoundParticleSystem = vehicleIdentity.Exhausts[0];

		if (vehicleIdentity.Exhausts.Length == 2)
		{
			_mmFeedbackParticles[1].BoundParticleSystem = vehicleIdentity.Exhausts[1];
		}
	}
	
	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			_tapValue.CurrentValue += 10;
			_tapFeedbacks.PlayFeedbacks();
			MMVibrationManager.Haptic (HapticTypes.RigidImpact);
		}
	}
}