//this was semi vibe coded because i suck ASS at C#
using MelonLoader;
using Il2Cpp;
using UnityEngine;
using System.Reflection.Metadata;
using Il2CppSystem.Threading;
using System.IO;
using CustomKeybindApi;
using HarmonyLib;
using Il2Cpp_Scripts.Managers;
using System.Diagnostics;
using Il2CppSystem;

namespace QOLMod
{

    public class Main : MelonMod
    {

        //variable assigning
        private static bool showMenu = false;
        private static bool IsPaused = false;
        public bool showTASMenu = false;
        public bool showSettingsMenu = false;
        public bool showReplayMenu = false;
        public float currentTime = 1.0f;
        public KeyCode menuKey = KeyCode.RightShift;
        public KeyCode freezeKey = KeyCode.RightAlt;
        //public KeyCode freezeKey = KeyCode.RightAlt;
        //public KeyCode menuKey = KeyCode.RightShift;
        public KeyCode testSave = KeyCode.PageDown;// this stays hard coded because its supposed to be...


        public override void OnInitializeMelon() // this is when the mod loads it logs so if it doesnt log its broken!!!
        {
            HelloWorld();
            string folderpath = Path.Combine(Application.persistentDataPath, "Replays/");
            if (!Directory.Exists(folderpath))
            {
                Directory.CreateDirectory(folderpath);
                MelonLogger.Msg("Replays folder has been made!");
            }

            string otherpath = File.ReadAllText(Path.Combine(Application.persistentDataPath, "DEMO_CustomKeybinds.json"));

            if (KeybindHandler.GetKeybind("SleddingGameTAS", "MenuKey") == "") // this is useless but im futureproofing alr
            {
                KeybindHandler.SaveKeybind("SleddingGameTAS", "FreezeKey", KeyCode.RightAlt);
                KeybindHandler.SaveKeybind("SleddingGameTAS", "MenuKey", KeyCode.RightShift);
                freezeKey = (KeyCode)int.Parse(KeybindHandler.GetKeybind("SleddingGameTAS", "FreezeKey"));
                menuKey = (KeyCode)int.Parse(KeybindHandler.GetKeybind("SleddingGameTAS", "MenuKey"));
            }

            else
            {
//                KeybindHandler.GetKeybind("SleddingGameTAS", "FreezeKey");
//                KeybindHandler.GetKeybind("SleddingGameTAS", "MenuKey");
                freezeKey = (KeyCode)int.Parse(KeybindHandler.GetKeybind("SleddingGameTAS", "FreezeKey"));
                menuKey = (KeyCode)int.Parse(KeybindHandler.GetKeybind("SleddingGameTAS", "MenuKey"));
            }
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

            if (Input.GetKeyDown(testSave))
            {
                SaveTASToFile();
            }

        }




        private void TogglePause()
        {
            IsPaused = !IsPaused;
            Time.timeScale = IsPaused ? 0.0f : 1.0f;
            MelonLogger.Msg(IsPaused ? "Game Paused" : "Game Resumed");
        }

        private void SaveTASToFile()
        {
            string path = Path.Combine(Application.persistentDataPath, "Replays/testsave.sgt");

            if (!File.Exists(path))
            {
                File.WriteAllText(path, "#hello world \n");
            }

            string content = "#this tas was made at " + System.DateTime.Now + "\n";

            File.AppendAllText(path, content);
        }

        private void NotWorking()
        {
            MelonLogger.Warning("ts aint workin homie just dont use ts");
        }


        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            if (sceneName == "Main Mountain Scene")
            {
                MelonLogger.Msg(sceneName, "Has Loaded");

                string[] deleteObjectsList =
{
                    "(Canvas) Pre-Game/UI_MainMenu/Panel/Layout Group/horizontal layout/(Button) Join",
                    "(Canvas) Pre-Game/UI_MainMenu/Panel/Layout Group/horizontal layout/(Button) Join - text chat only",
                    "(Canvas) Pre-Game/UI_MainMenu/Panel/Layout Group/space",
                };

                GameObject.Find("(Canvas) Pre-Game/UI_MainMenu/Panel/Layout Group/space").active = false;
                GameObject.Find("(Canvas) Pre-Game/UI_MainMenu/Panel/Layout Group/horizontal layout/(Button) Join").active = false;
                GameObject.Find("(Canvas) Pre-Game/UI_MainMenu/Panel/Layout Group/horizontal layout/(Button) Join - text chat only").active = false;
            }
        }

 //       public Rect tasWindowRect = new Rect(400, 100, 200, 150);

        public override void OnGUI()
        {


            if (!showMenu) return;

            GUI.Box(new Rect(100, 100, 250, 250), "Master TAS Menu");

            if (GUI.Button(new Rect(120, 140, 210, 40), showTASMenu ? "Close TAS Menu" : "Open TAS Menu"))
            {
                showTASMenu = !showTASMenu;

                
            }

            if (GUI.Button(new Rect(120, 190, 210, 40), showSettingsMenu ? "Close Settings Menu" : "Open Settings Menu"))
            {
                showSettingsMenu = !showSettingsMenu;
                NotWorking();
                
            }

            if (GUI.Button(new Rect(120, 240, 210, 40), showReplayMenu ? "Close Replay Menu" : "Open Replay Menu"))
            {
                showReplayMenu = !showReplayMenu;
                //NotWorking();
                MelonLogger.Msg("PS: i only made the menu");
            }

            if (showTASMenu) // i moved this if statement and removed the ! and it works (how)
            {
                // 1. Draw the Box first
                // Rect(x, y, width, height)
                GUI.Box(new Rect(100, 500, 250, 250), "TAS Menu");

                // 2. Draw buttons INSIDE the box by adding the box's X and Y
                // If box is at 200, and button should be 20 pixels inside... 200 + 20 = 220
                if (GUI.Button(new Rect(120, 540, 210, 40), IsPaused ? "Resume" : "Pause"))
                {
                    IsPaused = !IsPaused;

                    if (IsPaused)
                        Time.timeScale = 0.0f;
                    else
                        Time.timeScale = currentTime; // Return to whatever the slider is set to
                }

                // 2. THE SLIDER (Only runs if we aren't paused!)
                GUI.Label(new Rect(120, 590, 210, 20), "Speed: " + currentTime.ToString("F2"));

                // We update the variable regardless...
                currentTime = GUI.HorizontalSlider(new Rect(120, 610, 210, 30), currentTime, 0.0f, 1.0f);

                // ...BUT we only apply it to the game if we aren't currently paused
                if (!IsPaused)
                {
                    Time.timeScale = currentTime;
                }

                if (GUI.Button(new Rect(120, 640, 210, 40), "Frame Advance"))
                {
                    LobbyManager.Instance.LeaveLobby();

                    MelonLogger.Msg("im lazy");
                }

                if (GUI.Button(new Rect(120, 690, 210, 40), "Close Menu"))
                {
                    showTASMenu = false;
                }

            }

            if (showReplayMenu)
            {
                GUI.Box(new Rect(400, 120, 250, 300), "Replay Menu");

                if (GUI.Button(new Rect(420, 140, 210, 40), "New"))
                {
                    NotWorking();
                }

                if (GUI.Button(new Rect(420, 190, 210, 40), "Save"))
                {
                    NotWorking();
                }

                if (GUI.Button(new Rect(420, 240, 210, 40), "Load"))
                {
                    NotWorking();
                }

                if (GUI.Button(new Rect(420, 290, 210, 40), "Delete"))
                {
                    NotWorking();
                }

                if (GUI.Button(new Rect(420, 340, 210, 40), "Open Replay Folder"))
                {
                    string folderpath = Path.Combine(Application.persistentDataPath, "Replays/");

//                    if (OperatingSystemFamily.Windows)
//                    {
                        Process.Start("explorer.exe", @Path.Combine(Application.persistentDataPath, "Replays/"));
 //                   }
                }
            }
        }


        [HarmonyPatch(typeof(LobbySettingsManager), nameof(LobbySettingsManager.Instance.OnStartClient))]
        public static class OnStartClientPatch
        {
            [HarmonyPostfix]
            public static void PostFix()
            {
                if (PlayerReferenceManager.Instance == null || PlayerReferenceManager.Instance.GetLocalPlayerReference() == null)
                    return;
                bool isHost = PlayerReferenceManager.Instance.GetLocalPlayerReference().PlayerControl.hostControls.IsHost;

                if (!isHost)
                {
                    showMenu = false;
                    Time.timeScale = 1.0f;
                    IsPaused = false;
                    Application.Quit();
                }
            }
        }
    }
}