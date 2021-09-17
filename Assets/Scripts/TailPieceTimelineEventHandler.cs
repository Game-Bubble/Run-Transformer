using UnityEngine;

public class TailPieceTimelineEventHandler : MonoBehaviour
{
	TailPiece _tailPieceToActivate;
	
	public void Initialize(TailPiece tailPiece)
	{
		_tailPieceToActivate = tailPiece;
	}
	
	// this will be called from timeline
	public void ActivateTailPiece()
	{
		_tailPieceToActivate.gameObject.SetActive(true);
	}
}