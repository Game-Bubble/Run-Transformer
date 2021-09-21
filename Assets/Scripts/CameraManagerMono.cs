using Cinemachine;
using SO;
using UnityEngine;

public class CameraManagerMono : MonoBehaviour
{
	[SerializeField] CameraManagerChannelSO cameraManagerChannelSO;
	
	[SerializeField] CinemachineVirtualCamera _backCamera;
	[SerializeField] CinemachineVirtualCamera _sideCamera;
	[SerializeField] CinemachineVirtualCamera _topDownCamera;
	[SerializeField] CinemachineVirtualCamera _flyCamera;
	
	void Awake()
	{
		cameraManagerChannelSO.Initialize(this);
	}
	
	public void SetBackCameraActive()
	{
		_backCamera.gameObject.SetActive(true);
		_sideCamera.gameObject.SetActive(false);
		_topDownCamera.gameObject.SetActive(false);
	}

	public void SetSideCameraActive()
	{
		_sideCamera.gameObject.SetActive(true);
		_backCamera.gameObject.SetActive(false);
		_topDownCamera.gameObject.SetActive(false);
	}

	public void SetTopDownCameraActive()
	{
		_topDownCamera.gameObject.SetActive(true);
		_backCamera.gameObject.SetActive(false);
		_sideCamera.gameObject.SetActive(false);
	}

	public void SetFlyCameraActive()
	{
		_flyCamera.gameObject.SetActive(true);
		
		_topDownCamera.gameObject.SetActive(false);
		_backCamera.gameObject.SetActive(false);
		_sideCamera.gameObject.SetActive(false);
	}
}