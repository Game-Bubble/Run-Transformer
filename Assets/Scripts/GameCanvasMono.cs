using DG.Tweening;
using SO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameCanvasMono : MonoBehaviour
{
	[SerializeField] GameCanvasChannelSO _gameCanvasChannelSO;
	[SerializeField] GameObject _winPanel;
	[SerializeField] Image _levelFinishedText;

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
		_winPanel.SetActive(true);
		
		_levelFinishedText.DOFade(1f, 1f);
	}

	void OnNextLevel()
	{
		int buildIndexOfLastScene = SceneManager.sceneCount - 1;
		
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