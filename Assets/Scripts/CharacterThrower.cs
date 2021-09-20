using System;
using UnityEngine;

public class CharacterThrower : MonoBehaviour
{
	[SerializeField] FlyOffChannelSO _flyOffChannelSO;

	void OnEnable()
	{
		_flyOffChannelSO.TapFinished += ThrowCharacter;
	}

	void OnDisable()
	{
		_flyOffChannelSO.TapFinished -= ThrowCharacter;
	}

	void ThrowCharacter()
	{
		
	}
}