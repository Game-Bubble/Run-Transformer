using UnityEngine;

public class TailPieceDamager : MonoBehaviour
{
	[SerializeField] Collider _trigger;
	
	void OnTriggerEnter(Collider other)
	{
		TailPiece tailPiece = other.GetComponent<TailPiece>();

		if (tailPiece)
		{
			tailPiece.TakeHit();
			_trigger.enabled = false;
		}
	}
}