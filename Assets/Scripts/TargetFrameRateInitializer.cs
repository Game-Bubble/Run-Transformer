using UnityEngine;

public class TargetFrameRateInitializer : MonoBehaviour
{
	void Awake()
	{
		Application.targetFrameRate = 60;
	}
}