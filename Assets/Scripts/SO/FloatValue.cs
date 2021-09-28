using System;
using UnityEngine;

namespace SO
{
	[CreateAssetMenu(fileName = "Float Value", menuName = "SO/Float Value", order = 0)]
	public class FloatValue : ScriptableObject, ISerializationCallbackReceiver
	{
		public int Value;
		public int CurrentValue
		{
			get => _currentValue;
			set
			{
				_currentValue = value;
				OnValueChanged?.Invoke();
			}
		}
		[NonSerialized] int _currentValue;

		public event Action OnValueChanged;

		public void OnBeforeSerialize()
		{
		}

		public void OnAfterDeserialize()
		{
			CurrentValue = Value;
		}
	}
}