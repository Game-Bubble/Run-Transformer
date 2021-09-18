using System;
using UnityEngine;
using UnityEngine.Playables;

public class TailPiece : MonoBehaviour
{
	[SerializeField] PlayableDirector _playableDirector;
	
	Action<int> _tailPieceTakingHit;
	
	int _index;

	public void Initialize(Action<int> onTailPieceTakingHit, int index)
	{
		_tailPieceTakingHit = onTailPieceTakingHit;
		_index = index;
		gameObject.SetActive(false);
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