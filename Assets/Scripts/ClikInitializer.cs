using Tabtale.TTPlugins;
using UnityEngine;

public static class ClikInitializer
{
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	static void InitializeClik()
	{
		TTPCore.Setup();
	}
}