using UnityEngine;

public class TailController : MonoBehaviour
{
	TailPiece[] _tailPieces;
	int TailCount => _tailPieces.Length;

	void Awake()
	{
		_tailPieces = GetComponentsInChildren<TailPiece>();

		for (int i = 0; i < _tailPieces.Length; i++)
		{
			TailPiece tailPiece = _tailPieces[i];
			tailPiece.Initialize(OnTailPieceTakingHit, i);
		}
	}

	public void OnTailPiecePicking()
	{
		SetupAndPlayTailFormingSequence();
	}
	
	void OnTailPieceTakingHit(int x)
	{
		RemoveTailFromIndex(x);
	}
	
	void RemoveTailFromIndex(int index)
	{
		for (int i = 0; i < _tailPieces.Length; i++)
		{
			if (i >= index)
			{
				_tailPieces[i].gameObject.SetActive(false);
			}
		}
	}
	
	void SetupAndPlayTailFormingSequence()
	{
		for (int i = 0; i < TailCount; i++)
		{
			if (!_tailPieces[i].gameObject.activeSelf)
			{
				_tailPieces[i].gameObject.SetActive(true);
				_tailPieces[i].PlayVFXSequence();
				return;
			}
		}
	}
}