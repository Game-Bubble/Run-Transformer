using System;
using SO;
using UnityEngine;

public class TailPiecePicker : MonoBehaviour
{
	public event Action TailPiecePicking;
	
	[SerializeField] IntValue _score;
	
	void OnTriggerEnter(Collider other)
	{
		TailPiecePickable tailPiecePickable = other.GetComponent<TailPiecePickable>();

		if (tailPiecePickable)
		{
			TailPiecePicking?.Invoke();
			
			_score.CurrentValue++;
			
			Destroy(other.gameObject);
		}
	}
}