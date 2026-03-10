using MelonLoader;
using HarmonyLib;
using Il2Cpp;
using UnityEngine;
using System.Reflection.Metadata;


namespace QOLMod
{
    public class Main : MelonMod
    {
        public bool showMenu = false;
        public KeyCode menuKey = KeyCode.RightShift; //im hardcoding this because im lazy!!!

        public override void OnInitializeMelon() // this is when the mod loads it logs so if it doesnt log its broken!!!
        {
            HelloWorld();
        }

        public static void HelloWorld()
        {
            MelonLogger.Msg("herro from SleddingGameTAS, right shift to open menu");
        }
        
        public override void OnUpdate()
        {
            // check for key press
            if (Input.GetKeyDown(menuKey))
            {
                showMenu = !showMenu;
            }
        }

        void ResumeGame()
        {
            Time.timeScale = 1.0f;
        }

        void PauseGame()
        {
            Time.timeScale = 0.0f;
        }

        public override void OnGUI()
        {
            if (!showMenu) return;

            // draw the menu yk what im sayin
            GUI.Box(new Rect(10, 10, 200, 150), "TAS Menu");

            // add a button
            if (GUI.Button(new Rect(20, 40, 160, 40), "test"))
            {
                MelonLogger.Msg("clicked");
            }

            if (GUI.Button(new Rect(20, 90, 160, 40), "Close Menu"))
            {
                showMenu = false;
            }
        }

        [HarmonyPatch(typeof(PlayerReferenceManager), nameof(PlayerReferenceManager.OnPlayerReferenceAdded))]
        public static class AnyName
        {
            //insert tas code here
        }
    }
}
