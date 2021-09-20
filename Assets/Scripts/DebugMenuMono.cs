using SO;
using UnityEngine;

public class DebugMenuMono : MonoBehaviour
{
	[SerializeField] DebugMenuChannelSO _debugMenuChannelSO;
	[SerializeField] GameObject _targetObj;
	
	public void ChangeActiveState()
	{
		_targetObj.SetActive(!_targetObj.activeSelf);
		
		_debugMenuChannelSO.DebugMenuActiveStateChanged.Invoke(_targetObj.activeSelf);
	}
}