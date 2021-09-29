using SO;
using UnityEngine;

public class WallHitter : MonoBehaviour
{
	[SerializeField] ParticleSystem _crashParticle;
	[SerializeField] FlyOffChannelSO _flyOffChannelSO;
	[SerializeField] GameObject[] _gameObjectsThatWillDeactivatedOnHit;
	
	void OnTriggerEnter(Collider other)
	{
		HitWall hitWall = other.GetComponent<HitWall>();

		if (hitWall)
		{
			// TODO: play crash vfx and throw player
			_crashParticle.Play();
			_flyOffChannelSO.CrashHappened();

			foreach (GameObject o in _gameObjectsThatWillDeactivatedOnHit)
			{
				o.SetActive(false);
			}
			
			Destroy(gameObject, 1f);
		}
	}
}