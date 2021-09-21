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
		GameObject characterToThrow = Instantiate(_characterToThrow, _throwPoint.position, Quaternion.identity);
		CharacterThruster characterThruster = characterToThrow.GetComponent<CharacterThruster>();
		characterThruster.Thrust(_throwPoint.forward * 100f);
		_cameraManagerChannelSO.SendTargetChangeSignal(characterThruster.RootRigidbody.transform);
		_cameraManagerChannelSO.SendFlyCameraActiveSignal();
	}
}