using SO;
using TMPro;
using UnityEngine;

public class ScoreDisplayer : MonoBehaviour
{
	[SerializeField] IntValue _score;
	[SerializeField] TextMeshProUGUI _textMeshProUGUI;

	void OnEnable()
	{
		_score.OnValueChanged += OnScoreUpdate;
	}

	void OnDisable()
	{
		_score.OnValueChanged -= OnScoreUpdate;
	}

	void OnScoreUpdate()
	{
		_textMeshProUGUI.text = _score.CurrentValue.ToString();
	}
}