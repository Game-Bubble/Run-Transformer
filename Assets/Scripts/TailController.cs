using System.Linq;
using SO;
using UnityEngine;

public class TailController : MonoBehaviour
{
	[SerializeField] TailPiecePicker _tailPiecePicker;
	[SerializeField] IntValue _score;
	
	TailPiece[] _tailPieces;
	int TailCount => _tailPieces.Length;

	void OnEnable()
	{
		// get all tail pieces and initialize them
		_tailPieces = GetComponentsInChildren<TailPiece>();
		for (int i = 0; i < _tailPieces.Length; i++)
		{
			TailPiece tailPiece = _tailPieces[i];
			tailPiece.Initialize(i);
		}
		
		foreach (TailPiece tailPiece in _tailPieces)
		{
			tailPiece.TailPieceTakingHit += OnTailPieceTakingHit;
		}

		_tailPiecePicker.TailPiecePicking += OnTailPiecePicking;
	}

	void OnDisable()
	{
		foreach (TailPiece tailPiece in _tailPieces)
		{
			tailPiece.TailPieceTakingHit -= OnTailPieceTakingHit;
		}
		
		_tailPiecePicker.TailPiecePicking -= OnTailPiecePicking;
	}

	void OnTailPiecePicking(Material tailPieceMaterial)
	{
		SetupAndPlayTailFormingSequence(tailPieceMaterial);
		_score.CurrentValue++;
	}
	
	void OnTailPieceTakingHit(int x)
	{
		RemoveTailFromIndex(x);
		UpdateScore();
	}

	void UpdateScore()
	{
		int val = _tailPieces.Count(tailPiece => tailPiece.gameObject.activeSelf);
		_score.CurrentValue = val;
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
	
	void SetupAndPlayTailFormingSequence(Material tailPieceMaterial)
	{
		for (int i = 0; i < TailCount; i++)
		{
			if (!_tailPieces[i].gameObject.activeSelf)
			{
				_tailPieces[i].SetMaterial(tailPieceMaterial);
				_tailPieces[i].gameObject.SetActive(true);
				_tailPieces[i].PlayVFXSequence();
				return;
			}
		}
	}
}