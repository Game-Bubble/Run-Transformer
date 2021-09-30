using SO;
using UnityEngine;

public class ThrownCharacter : MonoBehaviour
{
	[SerializeField] GameCanvasChannelSO _gameCanvasChannelSO;
	bool _isCollisionMessageSent;
	
	void OnCollisionEnter(Collision other)
	{
		if (!_isCollisionMessageSent)
		{
			LandingGround landingGround = other.collider.GetComponent<LandingGround>();
			
			if (landingGround)
			{
				Invoke(nameof(SendLevelFinished), 1f);
				_isCollisionMessageSent = true;
			}
		}
	}

	void SendLevelFinished()
	{
		_gameCanvasChannelSO.LevelFinished();
	}
}