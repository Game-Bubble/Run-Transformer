using UnityEngine;

public class TailPieceDamager : MonoBehaviour
{
	[SerializeField] Collider _trigger;
	
	void OnTriggerEnter(Collider other)
	{
		TailPieceTriggerMessageSender tailPieceTriggerMsgSender = other.GetComponent<TailPieceTriggerMessageSender>();

		if (tailPieceTriggerMsgSender)
		{
			tailPieceTriggerMsgSender._tailPiece.TakeHit();
			_trigger.enabled = false;
		}
	}
}