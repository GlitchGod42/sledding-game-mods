//this was semi vibe coded because i suck ASS at C#
using MelonLoader;
using Il2Cpp;
using UnityEngine;
using System.Reflection.Metadata;
using Il2CppSystem.Threading;


namespace QOLMod
{
    public class Main : MelonMod
    {
        public bool showMenu = false;
        public bool IsPaused = false;
        public bool slowMo = false;
        public float currentTime = 1.0f;
        public KeyCode freezeKey = KeyCode.RightAlt;
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
            // Handle all input in OnUpdate, NOT OnGUI
            if (Input.GetKeyDown(menuKey))
            {
                showMenu = !showMenu;
            }

            if (Input.GetKeyDown(freezeKey))
            {
                TogglePause();
            }
        }

        private void TogglePause()
        {
            IsPaused = !IsPaused;
            Time.timeScale = IsPaused ? 0.0f : 1.0f;
            MelonLogger.Msg(IsPaused ? "Game Paused" : "Game Resumed");
        }

        private void ToggleSlowMo()
        {
            slowMo = !slowMo;
            Time.timeScale = slowMo ? 0.5f : 1.0f;
            MelonLogger.Msg(slowMo ? "Slow Motion Enabled" : "Slow Motion Disabled");
        }

        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            if (sceneName == "Main Mountain Scene")
            {
                string[] deleteObjectsList = 
                {
                    "(Canvas) Pre-Game/UI_MainMenu/Panel/Layout Group/horizontal layout/(Button) Join",
                    "(Canvas) Pre-Game/UI_MainMenu/Panel/Layout Group/horizontal layout/(Button) Join - text chat only"
                };
            }
        }

        public override void OnGUI()
        {
            if (!showMenu) return;

            // 1. Draw the Box first
            // Rect(x, y, width, height)
            GUI.Box(new Rect(100, 100, 250, 250), "TAS Menu");

            // 2. Draw buttons INSIDE the box by adding the box's X and Y
            // If box is at 100, and button should be 20 pixels inside... 100 + 20 = 120
            if (GUI.Button(new Rect(120, 140, 210, 40), IsPaused ? "Resume" : "Pause"))
            {
                IsPaused = !IsPaused;

                if (IsPaused)
                    Time.timeScale = 0.0f;
                else
                    Time.timeScale = currentTime; // Return to whatever the slider is set to
            }

            // 2. THE SLIDER (Only runs if we aren't paused!)
            GUI.Label(new Rect(120, 190, 210, 20), "Speed: " + currentTime.ToString("F2"));

            // We update the variable regardless...
            currentTime = GUI.HorizontalSlider(new Rect(120, 210, 210, 30), currentTime, 0.0f, 1.0f);

            // ...BUT we only apply it to the game if we aren't currently paused
            if (!IsPaused)
            {
                Time.timeScale = currentTime;
            }

            if (GUI.Button(new Rect(120, 240, 210, 40), "Frame Advance"))
            {
                if (IsPaused)
                {
                    Time.timeScale = 1.0f;

                    Task.Delay(TimeSpan.FromSeconds(Time.deltaTime));

                    Time.timeScale = 0.0f;
                }

                else
                {
                    MelonLogger.Warning("You aint paused dummy.");
                }   
            }

            if (GUI.Button(new Rect(120, 290, 210, 40), "Close Menu"))
            {
                showMenu = false;
            }
        }
    }
}
