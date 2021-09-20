using System;
using UnityEngine;

public class TransformationArea : MonoBehaviour
{
	void OnTriggerEnter(Collider other)
	{
		PlayerController playerController = other.GetComponent<PlayerController>();

		if (playerController)
		{
			
		}
	}
}