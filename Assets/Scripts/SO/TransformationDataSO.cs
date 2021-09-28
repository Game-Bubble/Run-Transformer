using System;
using UnityEngine;

namespace SO
{
	[CreateAssetMenu(fileName = "Transformation Data SO", menuName = "SO/Transformation Data", order = 0)]
	public class TransformationDataSO : ScriptableObject
	{
		[SerializeField] TransformationScoreVehiclePair[] _transformationScoreVehiclePair;
		[SerializeField] VehicleIdentity _lowestScoreVehicle;

		public GameObject GetVehicle(int score)
		{
			GameObject vehicle = _lowestScoreVehicle.gameObject;

			int highestCarScore = -1;
			foreach (TransformationScoreVehiclePair transformationScoreVehiclePair in _transformationScoreVehiclePair)
			{
				if (score > transformationScoreVehiclePair.Score && highestCarScore < transformationScoreVehiclePair.Score)
				{
					vehicle = transformationScoreVehiclePair.VehiclePrefab.gameObject;
					highestCarScore = transformationScoreVehiclePair.Score;
				}
			}
			return vehicle;
		}
	}
		
	[Serializable]
	public struct TransformationScoreVehiclePair
	{
		public int Score;
		public VehicleIdentity VehiclePrefab;
	}
}
