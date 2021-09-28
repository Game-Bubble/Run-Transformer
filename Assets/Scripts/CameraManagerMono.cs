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
	[SerializeField] CinemachineVirtualCamera _tapCamera;
	[SerializeField] CinemachineVirtualCamera _vehicleCamera;

	CinemachineVirtualCamera _currentActiveCam;
	
	void Awake()
	{
		cameraManagerChannelSO.Initialize(this);
		_currentActiveCam = _backCamera;
	}

	public void SetBackCameraActive()
	{
		SetCameraActive(_backCamera);
	}

	public void SetSideCameraActive()
	{
		SetCameraActive(_sideCamera);
	}

	public void SetTopDownCameraActive()
	{
		SetCameraActive(_topDownCamera);
	}

	public void SetFlyCameraActive()
	{
		SetCameraActive(_flyCamera);	
	}
	
	public void SetTapCameraActiveSignal()
	{
		SetCameraActive(_tapCamera);
	}

	public void SetVehicleCameraActiveSignal()
	{
		SetCameraActive(_vehicleCamera);
	}

	public void SetTarget(Transform target)
	{
		_flyCamera.Follow = target;
		_topDownCamera.Follow = target;
		_backCamera.Follow = target;
		_sideCamera.Follow = target;
		_tapCamera.Follow = target;
		_vehicleCamera.Follow = target;
	}

	void SetCameraActive(CinemachineVirtualCamera virtualCamera)
	{
		_currentActiveCam.gameObject.SetActive(false);
		virtualCamera.gameObject.SetActive(true);
		_currentActiveCam = virtualCamera;
	}
}