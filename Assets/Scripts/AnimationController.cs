using UnityEngine;

public class AnimationController : MonoBehaviour
{
	[SerializeField] Animator _animator;

	readonly int _runId = Animator.StringToHash("Run");

	public void PlayRunAnimation(bool shouldPlay)
	{
		_animator.SetBool(_runId, shouldPlay);
	}
}