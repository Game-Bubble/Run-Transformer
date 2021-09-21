using DG.Tweening;
using SO;
using UnityEngine;
using UnityEngine.UI;

public class TapUI : MonoBehaviour
{
	[SerializeField] IntValue _tapValue;
	[SerializeField] Image _image;
	[SerializeField] DrivingManagerChannelSO _drivingManagerChannelSO;
	[SerializeField] CameraManagerChannelSO _cameraManagerChannelSO;
	
	[SerializeField] float _timeBeforeReset;
	
	float _currentResetTimer;
	float _currentFillAmount;
	
	void OnEnable()
	{
		_tapValue.OnValueChanged += OnTapValueChanged;
	}

	void OnDisable()
	{
		_tapValue.OnValueChanged -= OnTapValueChanged;
	}

	void OnTapValueChanged()
	{
		_currentResetTimer = 0f;
		DOVirtual.Float(_currentFillAmount / 100f, _tapValue.CurrentValue / 100f, 0.2f, OnImageFillAmountVirtualUpdate);
		_currentFillAmount = _tapValue.CurrentValue;
		if (_currentFillAmount >= 100f)
		{
			//tap finished
			gameObject.SetActive(false);
			_drivingManagerChannelSO.TapFinished();
			_cameraManagerChannelSO.SendBackCameraActiveSignal();
		}
	}

	void Update()
	{
		_currentResetTimer += Time.deltaTime;
		if (_currentResetTimer >= _timeBeforeReset)
		{
			_currentResetTimer -= _timeBeforeReset / 8f;
			_tapValue.CurrentValue = Mathf.Max(0, _tapValue.CurrentValue - 5);
		}
	}

	void OnImageFillAmountVirtualUpdate(float val)
	{
		_image.fillAmount = val;
	}
}