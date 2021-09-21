using UnityEngine;

namespace SO
{
	[CreateAssetMenu(fileName = "Camera Manager Channel SO", menuName = "SO/Camera Manager Channel", order = 0)]
	public class CameraManagerChannelSO : ScriptableObject
	{
		CameraManagerMono _cameraManagerMono;

		public void Initialize(CameraManagerMono camMono)
		{
			_cameraManagerMono = camMono;
		}
		
		public void SendBackCameraActiveSignal()
		{
			_cameraManagerMono.SetBackCameraActive();
		}

		public void SendSideCameraActiveSignal()
		{
			_cameraManagerMono.SetSideCameraActive();
		}

		public void SendTopDownCameraActiveSignal()
		{
			_cameraManagerMono.SetTopDownCameraActive();
		}

		public void SendFlyCameraActiveSignal()
		{
			
		}
	}
}
