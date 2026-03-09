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
            MelonLogger.Msg("herro from SleddingGameTAS");
        }

        [HarmonyPatch(typeof(PlayerReferenceManager), nameof(PlayerReferenceManager.OnPlayerReferenceAdded))]
        public static class AnyName
        {
            [HarmonyPostfix]
            public static void PostFix(int index)
            {
                
            }
        }
    }
}
