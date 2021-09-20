using SO;
using UnityEngine;

public class TapController : MonoBehaviour
{
	[SerializeField] IntValue _tapValue;

	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			_tapValue.CurrentValue += 10;
		}
	}
}