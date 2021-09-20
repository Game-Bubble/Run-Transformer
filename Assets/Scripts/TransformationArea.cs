using UnityEngine;
using UnityEngine.Playables;

public class TransformationArea : MonoBehaviour
{
	[SerializeField] PlayableDirector _playableDirector;
	
	void OnTriggerEnter(Collider other)
	{
		PlayerController playerController = other.GetComponent<PlayerController>();

		if (playerController)
		{
			_playableDirector.Play();		
		}
	}
}