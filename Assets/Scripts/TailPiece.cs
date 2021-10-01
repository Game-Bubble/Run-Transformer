using System;
using UnityEngine;
using UnityEngine.Playables;

public class TailPiece : MonoBehaviour
{
	public Action<int> TailPieceTakingHit;
	
	[SerializeField] PlayableDirector _playableDirector;
	[SerializeField] TailPieceTimelineEventHandler _tailPieceTimelineEventHandler;
	[SerializeField] GameObject _tailPieceWCollider;
	[SerializeField] Renderer[] _tailPieceRenderers;
	
	int _index;

	public void Initialize(int index)
	{
		_index = index;
		gameObject.SetActive(false);
		_tailPieceWCollider.SetActive(false);
		_tailPieceTimelineEventHandler.Initialize(_tailPieceWCollider);
	}
	
	public void TakeHit()
	{
		// let tailController know that I take hit
		TailPieceTakingHit.Invoke(_index);
	}

	public void PlayVFXSequence()
	{
		_playableDirector.Play();
	}

	public void SetMaterial(Material tailPieceMaterial)
	{
		foreach (Renderer tailPieceRenderer in _tailPieceRenderers)
		{
			tailPieceRenderer.material = tailPieceMaterial;
		}
	}
}