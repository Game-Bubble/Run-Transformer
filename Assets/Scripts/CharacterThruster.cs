using UnityEngine;

public class CharacterThruster : MonoBehaviour
{
	public Rigidbody RootRigidbody;

	public void Thrust(Vector3 force)
	{
		RootRigidbody.AddForce(force, ForceMode.VelocityChange);
	}
}