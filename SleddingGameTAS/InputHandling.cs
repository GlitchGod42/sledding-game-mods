using MelonLoader;
using Il2Cpp;
using UnityEngine;
using System.Reflection.Metadata;
using Il2CppSystem.Threading;
using Il2Cpp_Scripts.Managers;
using System.Diagnostics;
using Il2CppSystem;
using UnityEngine.Playables;


namespace QOLMod
{
        public class InputHandling
        {
        public static string curcontent = "";

        public static System.Diagnostics.Stopwatch racetimer = new System.Diagnostics.Stopwatch();
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

            public static void SaveTASToFile(string name)
            {
            // TODO: get the name to carry over from Main.cs to here
            string path = Path.Combine(Application.persistentDataPath, "Replays/", name, ".sgt");

            File.AppendAllText(path, curcontent);
            }

            public static void InitTAS(string name)
            {
                string path = Path.Combine(Application.persistentDataPath, "Replays/", name,".sgt");

                File.AppendAllText(path, "# this was generated with SleddingGameTAS\n");
            }

            public static int raceCooldown = Race.RACE_COUNTDOWN;

            
            public static void InputRecording() // TODO: make it less jank but uhh im lazy yk what im sayin
            {
                

               float CurrentRaceTime = (float)racetimer.GetTime();

                if (Input.GetKeyDown(KeyCode.W))
                {
                    curcontent = curcontent + CurrentRaceTime.ToString("F2") + " hold w\n";
                }
                if (Input.GetKeyDown(KeyCode.A))
                {
                    curcontent = curcontent + CurrentRaceTime.ToString("F2") + " hold a\n";
                }
                if (Input.GetKeyDown(KeyCode.S))
                {
                    curcontent = curcontent + CurrentRaceTime.ToString("F2") + " hold s\n";
                }
                if (Input.GetKeyDown(KeyCode.D))
                {
                    curcontent = curcontent + CurrentRaceTime.ToString("F2") + " hold d\n";
                }

                if (Input.GetKeyUp(KeyCode.W))
                {
                    curcontent = curcontent + CurrentRaceTime.ToString("F2") + " release w\n";
                }
                if (Input.GetKeyUp(KeyCode.A))
                {
                    curcontent = curcontent + CurrentRaceTime.ToString("F2") + " release a\n";
                }
                if (Input.GetKeyUp(KeyCode.S))
                {
                    curcontent = curcontent + CurrentRaceTime.ToString("F2") + " release s\n";
                }
                if (Input.GetKeyUp(KeyCode.D))
                {
                    curcontent = curcontent + CurrentRaceTime.ToString("F2") + " release d\n";
                }
            }
        }

        //TODO: make a input replaying thing..... this is gonna be pain
}