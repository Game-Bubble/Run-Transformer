using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class TailController : MonoBehaviour
{
	[SerializeField] TailPiece _tailPiecePrefab;
	[SerializeField] PlayableDirector _directorPrefab;
	[SerializeField] TimelineAsset _newTailPieceForming;

	List<TailPiece> _tailPieces = new List<TailPiece>();
	int TailCount => _tailPieces.Count;

	public void SetupAndPlayTailFormingSequence()
	{
		Vector3 nextTailPiecePosition = transform.position + Vector3.forward * (TailCount * -_tailPiecePrefab.zLength);
		TailPiece instantiatedTailPiece = Instantiate(_tailPiecePrefab, nextTailPiecePosition, Quaternion.identity);
		_tailPieces.Add(instantiatedTailPiece);
		
		// prepare timeline for vfx
		PlayableDirector director = Instantiate(_directorPrefab);
		director.GetComponent<TailPieceTimelineEventHandler>().Initialize(instantiatedTailPiece);
		director.playableAsset = _newTailPieceForming;

		foreach (PlayableBinding playableAssetOutput in director.playableAsset.outputs)
		{
			TrackAsset track = (TrackAsset)playableAssetOutput.sourceObject;
			director.SetGenericBinding(track, instantiatedTailPiece);
		}
		
		// actual playing...
		director.Play();
	}
	
	public void RemoveTailFromIndex(int index)
	{
		for (int i = 0; i < _tailPieces.Count; i++)
		{
			if (i >= index)
			{
				_tailPieces.RemoveAt(i);
			}
		}
	}
}