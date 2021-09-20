using System;
using UnityEngine;

public class CharacterThrower : MonoBehaviour
{
	[SerializeField] FlyOffChannelSO _flyOffChannelSO;

	void OnEnable()
	{
		_flyOffChannelSO.TapFinished += ActivateThrowStage;
	}

	void OnDisable()
	{
		_flyOffChannelSO.TapFinished -= ActivateThrowStage;
	}

	void ActivateThrowStage()
	{
		// TODO: camera change, then throw
	}
}