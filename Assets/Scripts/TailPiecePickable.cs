using UnityEngine;

public class TailPiecePickable : MonoBehaviour
{
	[SerializeField] Material _tailPieceMaterial;

	public Material GetMaterial => _tailPieceMaterial;
}