using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Fly Off Channel SO", menuName = "SO/Fly Off Channel", order = 0)]
public class FlyOffChannelSO : ScriptableObject
{
	public Action TapFinished;
}