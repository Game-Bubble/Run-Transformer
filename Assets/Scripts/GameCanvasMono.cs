using DG.Tweening;
using SO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameCanvasMono : MonoBehaviour
{
	[SerializeField] GameCanvasChannelSO _gameCanvasChannelSO;
	[SerializeField] GameObject _winPanel;
	[SerializeField] GameObject _scorePanel;
	[SerializeField] Image _levelFinishedText;
	[SerializeField] Image _nextButton;

	void OnEnable()
	{
		_gameCanvasChannelSO.LevelFinished += OnLevelFinished;
		_gameCanvasChannelSO.GoingNextLevel += OnNextLevel;
	}

	void OnDisable()
	{
		_gameCanvasChannelSO.LevelFinished -= OnLevelFinished;
		_gameCanvasChannelSO.GoingNextLevel -= OnNextLevel;
	}

	void OnLevelFinished()
	{
		_levelFinishedText.color = new Color(_levelFinishedText.color.r, _levelFinishedText.color.g, _levelFinishedText.color.b, 0f);
		_levelFinishedText.rectTransform.localScale = Vector3.zero;
		
		_nextButton.color = new Color(_nextButton.color.r, _nextButton.color.g, _nextButton.color.b, 0f);
		_nextButton.rectTransform.localScale = Vector3.zero;

		_winPanel.SetActive(true);
		_scorePanel.SetActive(false);
		
		_levelFinishedText.DOFade(1f, 1f);
		_levelFinishedText.rectTransform.DOScale(1f, 1f).SetEase(Ease.OutBounce);

		_nextButton.DOFade(1f, 1f).SetDelay(0.25f);
		_nextButton.rectTransform.DOScale(1f, 1f).SetEase(Ease.OutBounce).SetDelay(0.25f);
	}

	void OnNextLevel()
	{
		int buildIndexOfLastScene = SceneManager.sceneCountInBuildSettings - 1;
		
		if (SceneManager.GetActiveScene().buildIndex + 1 > buildIndexOfLastScene)
		{
			SceneManager.LoadScene(0);
		}
		else
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		}
	}
}