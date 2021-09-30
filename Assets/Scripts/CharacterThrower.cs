using SO;
using UnityEngine;

public class CharacterThrower : MonoBehaviour
{
	[SerializeField] FlyOffChannelSO _flyOffChannelSO;
	[SerializeField] VehicleSpawnManagerChannelSO _vehicleSpawnManagerChannelSO;
	[SerializeField] CameraManagerChannelSO _cameraManagerChannelSO;
	
	[SerializeField] Transform _throwPoint;
	[SerializeField] GameObject _characterToThrow;

	float _throwPower;
	
	void OnEnable()
	{
		_flyOffChannelSO.CrashHappened += ActivateThrowStage;
		_vehicleSpawnManagerChannelSO.VehicleSpawned += RegisterVehicleThrowPower;
	}

	void OnDisable()
	{
		_flyOffChannelSO.CrashHappened -= ActivateThrowStage;
		_vehicleSpawnManagerChannelSO.VehicleSpawned -= RegisterVehicleThrowPower;
	}

	void RegisterVehicleThrowPower(VehicleIdentity vi)
	{
		_throwPower = vi.GetComponent<MovementController>().ThrowPower;
	}

	void ActivateThrowStage()
	{
		// TODO: then throw
		GameObject characterToThrow = Instantiate(_characterToThrow, _throwPoint.position, Quaternion.identity);
		CharacterThruster characterThruster = characterToThrow.GetComponent<CharacterThruster>();
		characterThruster.Thrust(_throwPoint.forward * _throwPower);
		_cameraManagerChannelSO.SendTargetChangeSignal(characterThruster.RootRigidbody.transform);
		_cameraManagerChannelSO.SendFlyCameraActiveSignal();
	}
}