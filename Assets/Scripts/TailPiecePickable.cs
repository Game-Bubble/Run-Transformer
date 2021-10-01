using UnityEngine;

public class TailPiecePickable : MonoBehaviour
{
	[SerializeField] Renderer _tailPieceRenderer;

	public Material GetMaterial => _tailPieceRenderer.material;
}