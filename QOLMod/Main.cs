using MelonLoader;
using HarmonyLib;
using Il2Cpp;


namespace QOLMod
{
    public class Main : MelonMod
    {
        public override void OnInitializeMelon()
        {
            HelloWorld();
        }

        public static void HelloWorld()
        {
            MelonLogger.Msg("herro from QOLMod");
        }

        [HarmonyPatch(typeof(PlayerReferenceManager), nameof(PlayerReferenceManager.OnPlayerReferenceAdded))]
        public static class AnyName
        {
            [HarmonyPostfix]
            public static void PostFix(int index)
            {
                LobbySettings lobbySettings = LobbySettingsManager.Instance.GetLobbySettings();

                lobbySettings.maxBuildableItems = 2147483647;

                PlayerReferenceManager.Instance.GetLocalPlayerReference().PlayerControl.buildingController.OnLobbySettingsChanged(lobbySettings);
            }
        }
    }
}
