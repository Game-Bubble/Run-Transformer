using SO;
using UnityEngine;

public class VCamIdentityMono : MonoBehaviour
{
	public VcamIdentitySO VcamIdentitySO;

	void OnEnable()
	{
		VcamIdentitySO.VCamIdentityMono = this;
	}

	void OnDisable()
	{
		VcamIdentitySO.VCamIdentityMono = null;
	}
}