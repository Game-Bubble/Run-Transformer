using UnityEngine;

public class TailPieceTimelineEventHandler : MonoBehaviour
{
	GameObject _objectToActivate;
	
	public void Initialize(GameObject tailPieceWCollider)
	{
		_objectToActivate = tailPieceWCollider;
	}
	
	// this will be called from timeline
	public void ActivateTailPiece()
	{
		_objectToActivate.SetActive(true);
	}
}