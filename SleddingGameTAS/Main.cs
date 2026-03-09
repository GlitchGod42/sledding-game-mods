using MelonLoader;
using HarmonyLib;
using Il2Cpp;
using UnityEngine;


namespace QOLMod
{
    public class Main : MelonMod
    {
        public override void OnEarlyInitializeMelon()
        {
            var openMenu = KeyCode.RightShift;
            // this is setting the bind for opening the menu im hardcoding it because
            // im lazy if you want to change it then compile it yourself (does this make me lazy? uhhhh fuck)
        }
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
