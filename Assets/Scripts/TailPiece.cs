using System;
using UnityEngine;
using UnityEngine.Playables;

public class TailPiece : MonoBehaviour
{
	[SerializeField] PlayableDirector _playableDirector;
	[SerializeField] TailPieceTimelineEventHandler _tailPieceTimelineEventHandler;
	[SerializeField] GameObject _tailPieceWCollider;
	
	Action<int> _tailPieceTakingHit;
	
	int _index;

	public void Initialize(Action<int> onTailPieceTakingHit, int index)
	{
		_tailPieceTakingHit = onTailPieceTakingHit;
		_index = index;
		gameObject.SetActive(false);
		_tailPieceWCollider.SetActive(false);
		_tailPieceTimelineEventHandler.Initialize(_tailPieceWCollider);
	}
	
	public void TakeHit()
	{
		// let tailController know that I take hit
		_tailPieceTakingHit.Invoke(_index);
	}

	public void PlayVFXSequence()
	{
		_playableDirector.Play();
	}
}