using SO;
using UnityEngine;

public class WallHitter : MonoBehaviour
{
	[SerializeField] ParticleSystem _crashParticle;
	[SerializeField] FlyOffChannelSO _flyOffChannelSO;
	[SerializeField] GameObject _vehicleVisuals;
	
	void OnTriggerEnter(Collider other)
	{
		HitWall hitWall = other.GetComponent<HitWall>();

		if (hitWall)
		{
			// TODO: play crash vfx and throw player
			_crashParticle.Play();
			_flyOffChannelSO.CrashHappened();
			
			_vehicleVisuals.SetActive(false);
			Destroy(gameObject, 1f);
		}
	}
}