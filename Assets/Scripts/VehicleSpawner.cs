using SO;
using UnityEngine;

public class VehicleSpawner : MonoBehaviour
{
	[SerializeField] TransformationManagerChannelSO _transformationManagerChannelSO;

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
		Instantiate(vehicleToSpawn, transform.position, Quaternion.identity);
	}
}