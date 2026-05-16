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
using JetBrains.Annotations;

namespace QOLMod
{
        public class InputHandling
        {
            public static string curcontent = "test";
        public static void SaveTestFile()
            {
            string testpath = Path.Combine(Application.persistentDataPath, "Replays/testsave.sgt");

            if (!File.Exists(testpath))
            {
                File.WriteAllText(testpath, "#hello world \n");
            }

            string testcontent = "#this tas was made at " + System.DateTime.Now + "\n";

            File.AppendAllText(testpath, testcontent);   
            }

            public static void SaveTASToFile()
            {
            string path = Path.Combine(Application.persistentDataPath, "Replays/currentTAS.sgt");

            if (!File.Exists(path))
            {
                File.WriteAllText(path, "# test");
            }

            
            }

            public static int raceCooldown = Race.RACE_COUNTDOWN;

            public static void InputRecording()
            {
                if (Input.GetKeyDown(KeyCode.W))
                {
                    string content = curcontent + "w";
                }
            }
        }
}