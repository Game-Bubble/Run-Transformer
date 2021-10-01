using UnityEditor;

namespace Editor
{
	public static class KeystoreSigner
	{
		[MenuItem("GameBubble/Sign Keystore")]
		static void SignKeystore()
		{
			PlayerSettings.Android.useCustomKeystore = true;
			PlayerSettings.Android.keystoreName = "gamebubble.keystore";
			PlayerSettings.Android.keyaliasName = "gamebubble";
			PlayerSettings.Android.keystorePass = "whm*1xgO0r1*!ctM";
			PlayerSettings.Android.keyaliasPass = "whm*1xgO0r1*!ctM";
		}
	}
}
