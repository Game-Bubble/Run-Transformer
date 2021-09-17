using UnityEngine;

public class TailPiecePicker : MonoBehaviour
{
	[SerializeField] TailController _tailController;
	
	public void OnTailPiecePicking()
	{
		_tailController.SetupAndPlayTailFormingSequence();
	}
}