using System.Linq;
using SO;
using UnityEngine;

public class TailController : MonoBehaviour
{
	[SerializeField] TailPiecePicker _tailPiecePicker;
	[SerializeField] IntValue _score;
	
	TailPiece[] _tailPieces;
	int TailCount => _tailPieces.Length;

	void Awake()
	{
		_tailPieces = GetComponentsInChildren<TailPiece>();

		for (int i = 0; i < _tailPieces.Length; i++)
		{
			TailPiece tailPiece = _tailPieces[i];
			tailPiece.Initialize(i);
		}
	}

	void OnEnable()
	{
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

	void OnTailPiecePicking()
	{
		SetupAndPlayTailFormingSequence();
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