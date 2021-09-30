using UnityEngine;

public class CharacterThruster : MonoBehaviour
{
	public Rigidbody RootRigidbody;
	[SerializeField] Rigidbody[] RigidbodiesToThrust;

	public void Thrust(Vector3 force)
	{
		foreach (Rigidbody rbd in RigidbodiesToThrust)
		{
			rbd.AddForce(force, ForceMode.VelocityChange);
		}
	}
}