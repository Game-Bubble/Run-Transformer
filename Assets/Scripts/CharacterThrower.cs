using SO;
using UnityEngine;

public class CharacterThrower : MonoBehaviour
{
	[SerializeField] FlyOffChannelSO _flyOffChannelSO;
	[SerializeField] CameraManagerChannelSO _cameraManagerChannelSO;
	
	[SerializeField] Transform _throwPoint;
	[SerializeField] GameObject _characterToThrow;
	
	void OnEnable()
	{
		_flyOffChannelSO.CrashHappened += ActivateThrowStage;
	}

	void OnDisable()
	{
		_flyOffChannelSO.CrashHappened -= ActivateThrowStage;
	}

	void ActivateThrowStage()
	{
		// TODO: then throw
		_cameraManagerChannelSO.SendFlyCameraActiveSignal();
		GameObject characterToThrow = Instantiate(_characterToThrow, _throwPoint.position, Quaternion.identity);
	}
}