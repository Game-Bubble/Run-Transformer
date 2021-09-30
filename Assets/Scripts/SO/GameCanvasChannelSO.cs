using System;
using UnityEngine;

namespace SO
{
	[CreateAssetMenu(fileName = "GameCanvasChannelSO", menuName = "SO/GameCanvasChannel", order = 0)]
	public class GameCanvasChannelSO : ScriptableObject
	{
		public Action LevelFinished;
		public Action GoingNextLevel;

		public void GoToNextLevel()
		{
			GoingNextLevel();
		}
	}
}
