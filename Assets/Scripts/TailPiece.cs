using UnityEngine;

public class TailPiece : MonoBehaviour
{
	public float zLength;
	
	TailController _tailController;
	int _index;

	public void Initialize(TailController tailController)
	{
		_tailController = tailController;
	}
	
	public void TakeHit()
	{
		// let tailController know that I take hit
		_tailController.RemoveTailFromIndex(_index);
	}
}