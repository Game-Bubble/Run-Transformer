using SO;
using SO.Move_Data;
using UnityEngine;

public class SRChannel : MonoBehaviour
{
	[SerializeField] MovementDataSO playerDataSO;
	[SerializeField] CameraManagerChannelSO _cameraManagerChannelSO;
	[SerializeField] ObstacleManagerChannelSO _obstacleManagerChannelSO;
	
	void OnEnable()
	{
		SROptions.ForwardMoveSpeedChanging += OnForwardMoveSpeedChanging;
		SROptions.SideMoveSpeedChanging += OnSideMoveSpeedChanging;
		SROptions.SetBackCameraActive += OnBackCameraActive;
		SROptions.SetSideCameraActive += OnSideCameraActive;
		SROptions.SetTopCameraActive += OnTopCameraActive;
		SROptions.ObstacleHitSpeedChanging += OnObstacleHitSpeedChanging;
		SROptions.ObstacleCountChanging += OnObstacleCountChanging;
	}

	void OnDisable()
	{
		SROptions.ForwardMoveSpeedChanging -= OnForwardMoveSpeedChanging;
		SROptions.SideMoveSpeedChanging -= OnSideMoveSpeedChanging;
		SROptions.SetBackCameraActive -= OnBackCameraActive;
		SROptions.SetSideCameraActive -= OnSideCameraActive;
		SROptions.SetTopCameraActive -= OnTopCameraActive;
	}
	
	void OnObstacleCountChanging(int val)
	{
		_obstacleManagerChannelSO.SetObstacleCount(val);
	}

	void OnObstacleHitSpeedChanging(int val)
	{
		_obstacleManagerChannelSO.SetObstacleHitSpeed(val);
	}


	void OnTopCameraActive()
	{
		_cameraManagerChannelSO.SendTopDownCameraActiveSignal();
	}

	void OnSideCameraActive()
	{
		_cameraManagerChannelSO.SendSideCameraActiveSignal();
	}

	void OnBackCameraActive()
	{
		_cameraManagerChannelSO.SendBackCameraActiveSignal();
	}

	void OnSideMoveSpeedChanging(float val)
	{
		playerDataSO.sideMoveSpeedMultiplier = val;
	}
	
	void OnForwardMoveSpeedChanging(float val)
	{
		playerDataSO.forwardMoveSpeed = val;
	}
}