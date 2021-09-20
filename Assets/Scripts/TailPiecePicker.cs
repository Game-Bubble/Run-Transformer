using System;
using UnityEngine;

public class TailPiecePicker : MonoBehaviour
{
	public event Action TailPiecePicking;
	
	void OnTriggerEnter(Collider other)
	{
		TailPiecePickable tailPiecePickable = other.GetComponent<TailPiecePickable>();

		if (tailPiecePickable)
		{
			TailPiecePicking?.Invoke();
			
			Destroy(other.gameObject);
		}
	}
}