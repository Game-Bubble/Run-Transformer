using System;
using UnityEngine;

public class WallHitter : MonoBehaviour
{
	void OnTriggerEnter(Collider other)
	{
		HitWall hitWall = other.GetComponent<HitWall>();

		if (hitWall)
		{
			// TODO: play crash vfx and throw player
			
		}
	}
}