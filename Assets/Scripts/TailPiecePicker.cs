using UnityEngine;

public class TailPiecePicker : MonoBehaviour
{
	[SerializeField] TailController _tailController;
	
	void OnTriggerEnter(Collider other)
	{
		TailPiecePickable tailPiecePickable = other.GetComponent<TailPiecePickable>();

		if (tailPiecePickable)
		{
			_tailController.OnTailPiecePicking();
			Destroy(other.gameObject);
		}
	}
}