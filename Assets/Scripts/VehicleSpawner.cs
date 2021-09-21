using SO;
using UnityEngine;

public class VehicleSpawner : MonoBehaviour
{
	[SerializeField] TransformationManagerChannelSO _transformationManagerChannelSO;
	[SerializeField] VehicleSpawnManagerChannelSO _vehicleSpawnManagerChannelSO;
	
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
		GameObject vehicle = Instantiate(vehicleToSpawn, transform.position, Quaternion.identity);
		VehicleIdentity vehicleIdentity = vehicle.GetComponent<VehicleIdentity>();
		_vehicleSpawnManagerChannelSO.VehicleSpawned(vehicleIdentity);
	}
}