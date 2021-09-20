using SO;
using UnityEngine;

public class VehicleCreationTimelineSignalReceiver : MonoBehaviour
{
	[SerializeField] IntValue _score;
	[SerializeField] TransformationDataSO _transformationDataSO;
	[SerializeField] TransformationManagerChannelSO _transformationManagerChannelSO;
	
	public void SpawnVehicle()
	{
		GameObject vehicle = _transformationDataSO.GetVehicle(_score.CurrentValue);
		_transformationManagerChannelSO.VehicleSpawning(vehicle);
	}
}