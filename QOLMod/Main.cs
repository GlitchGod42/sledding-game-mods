using HarmonyLib;
using Il2Cpp;
using Il2Cpp_Scripts.Player;
using MelonLoader;


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

                float markerCooldown = Il2Cpp_Scripts.Player.PlayerTeleportationController.ResetSpawnCooldownTime;

                lobbySettings.maxBuildableItems = 2147483647; // this is for removing build limit

                //markerCooldown.ResetSpawnCooldownTime = 0f;

                Il2Cpp_Scripts.Player.PlayerTeleportationController.ResetSpawnCooldownTime = 0f; // marker return timer and doesnt work

                sledCooldown.sledUseCooldown = 0; //this is to get rid of sled use cooldown but it doesnt work FUCK

                Il2Cpp_Scripts.Managers.RaceManager.CELEBRATION_TIMER = 1.5f;

                PlayerReferenceManager.Instance.GetLocalPlayerReference().PlayerControl.buildingController.OnLobbySettingsChanged(lobbySettings);
            }
        }
    }
}
