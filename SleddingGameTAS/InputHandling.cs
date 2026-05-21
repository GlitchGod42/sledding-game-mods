using MelonLoader;
using Il2Cpp;
using UnityEngine;
using System.Reflection.Metadata;
using Il2CppSystem.Threading;
using Il2Cpp_Scripts.Managers;
using System.Diagnostics;
using Il2CppSystem;


namespace QOLMod
{
        public class InputHandling
        {
        public static string curcontent = "test\n";
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

            File.AppendAllText(path, curcontent);

            
            }

            public static int raceCooldown = Race.RACE_COUNTDOWN;

            
            public static void InputRecording() // mega jank but uhh i hope it works
            {
                var racetimer = Stopwatch.StartNew();

                float racetimer_ms = (float)racetimer.Elapsed.TotalMilliseconds;
                float racetimer_s = (float)racetimer.Elapsed.TotalSeconds;

                //string curcontent = "";

                string path = Path.Combine(Application.persistentDataPath, "Replays/currentTAS.sgt");

                if (!File.Exists(path))
                {
                    File.WriteAllText(path, curcontent);
                }

                if (Input.GetKeyDown(KeyCode.W))
                {
                    curcontent = curcontent + racetimer_s.ToString("F2") + "." + racetimer_ms.ToString("F2") + " hold w\n";
                }
                if (Input.GetKeyDown(KeyCode.A))
                {
                    curcontent = curcontent + racetimer_s.ToString("F2") + "." + racetimer_ms.ToString("F2") + " hold a\n";
                }
                if (Input.GetKeyDown(KeyCode.S))
                {
                    curcontent = curcontent + racetimer_s.ToString("F2") + "." + racetimer_ms.ToString("F2") + " hold s\n";
                }
                if (Input.GetKeyDown(KeyCode.D))
                {
                    curcontent = curcontent + racetimer_s.ToString("F2") + "." + racetimer_ms.ToString("F2") + " hold d\n";
                }

                if (Input.GetKeyUp(KeyCode.W))
                {
                    curcontent = curcontent + racetimer_s.ToString("F2") + "." + racetimer_ms.ToString("F2") + " release w\n";
                }
                if (Input.GetKeyUp(KeyCode.A))
                {
                    curcontent = curcontent + racetimer_s.ToString("F2") + "." + racetimer_ms.ToString("F2") + " release a\n";
                }
                if (Input.GetKeyUp(KeyCode.S))
                {
                    curcontent = curcontent + racetimer_s.ToString("F2") + "." + racetimer_ms.ToString("F2") + " release s\n";
                }
                if (Input.GetKeyUp(KeyCode.D))
                {
                    curcontent = curcontent + racetimer_s.ToString("F2") + "." + racetimer_ms.ToString("F2") + " release d\n";
                }
            }
        }
}