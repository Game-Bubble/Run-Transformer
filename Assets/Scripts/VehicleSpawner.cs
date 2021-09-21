using SO;
using UnityEngine;

public class VehicleSpawner : MonoBehaviour
{
	[SerializeField] TransformationManagerChannelSO _transformationManagerChannelSO;
	[SerializeField] VehicleSpawnManagerChannelSO _vehicleSpawnManagerChannelSO;
	[SerializeField] CameraManagerChannelSO _cameraManagerChannelSO;
	[SerializeField] Transform _vehicleSpawnTransform;

	void OnEnable()
	{
		_transformationManagerChannelSO.VehicleSpawning += SpawnVehicle;
	}

	void OnDisable()
	{
		_transformationManagerChannelSO.VehicleSpawning -= SpawnVehicle;
	}

	void SpawnVehicle(GameObject vehicleToSpawn)
	{
		GameObject vehicle = Instantiate(vehicleToSpawn, _vehicleSpawnTransform.position, Quaternion.identity);
		_cameraManagerChannelSO.SendTargetChangeSignal(vehicle.transform);
		VehicleIdentity vehicleIdentity = vehicle.GetComponent<VehicleIdentity>();
		_vehicleSpawnManagerChannelSO.VehicleSpawned(vehicleIdentity);
	}
}