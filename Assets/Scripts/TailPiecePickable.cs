using System;
using UnityEngine;

public class TailPiecePickable : MonoBehaviour
{
	void OnTriggerEnter(Collider other)
	{
		TailPiecePicker tailPiecePicker = other.GetComponent<TailPiecePicker>();

		if (tailPiecePicker)
		{
			tailPiecePicker.OnTailPiecePicking();
			Destroy(gameObject);
		}
	}
}