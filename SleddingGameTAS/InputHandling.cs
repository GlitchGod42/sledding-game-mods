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
        public class InputHandling
        {
            public static void SaveTestFile()
            {
            string path = Path.Combine(Application.persistentDataPath, "Replays/testsave.sgt");

            if (!File.Exists(path))
            {
                File.WriteAllText(path, "#hello world \n");
            }

            string content = "#this tas was made at " + System.DateTime.Now + "\n";

            File.AppendAllText(path, content);   
            }

            public static void SaveTASToFile()
            {
                //this is empty because i still havent figured out
                //input saving and why? bc im lazy
                //also im stupid and idk how to do it
            }
        }
}