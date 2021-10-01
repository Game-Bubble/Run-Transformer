using System;
using UnityEngine;

public class TailPiecePicker : MonoBehaviour
{
	public event Action<Material> TailPiecePicking;
	
	void OnTriggerEnter(Collider other)
	{
		TailPiecePickable tailPiecePickable = other.GetComponent<TailPiecePickable>();

		if (tailPiecePickable)
		{
			TailPiecePicking?.Invoke(tailPiecePickable.GetMaterial);
			
			Destroy(other.gameObject);
		}
	}
}