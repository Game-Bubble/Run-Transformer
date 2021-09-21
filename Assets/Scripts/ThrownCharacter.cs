using UnityEngine;
using UnityEngine.SceneManagement;

public class ThrownCharacter : MonoBehaviour
{
	void Update()
	{
		if (transform.position.y < -2)
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}
}