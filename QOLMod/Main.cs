using MelonLoader;
using HarmonyLib;
using Il2Cpp;


namespace QOLMod
{
    public class Main : MelonMod
    {
        public override void OnInitializeMelon() // this is when the mod loads it logs so if it doesnt log its broken!!!
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

                var sledCooldown = PlayerReferenceManager.Instance.GetLocalPlayerReference().PlayerControl.sledController;



                lobbySettings.maxBuildableItems = 2147483647; // this is for removing build limit

                sledCooldown.sledUseCooldown = 0; //this is to get rid of sled use cooldown but it doesnt work FUCK

                PlayerReferenceManager.Instance.GetLocalPlayerReference().PlayerControl.buildingController.OnLobbySettingsChanged(lobbySettings);
            }
        }
    }
}
