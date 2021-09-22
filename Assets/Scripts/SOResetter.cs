using SO;
using UnityEngine;

public class SOResetter : MonoBehaviour
{
	[SerializeField] IntValue[] _intValues;

	void Awake()
	{
		foreach (IntValue intValue in _intValues)
		{
			intValue.CurrentValue = intValue.Value;
		}
	}
}