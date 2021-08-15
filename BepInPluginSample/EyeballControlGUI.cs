using COM3D2.LillyUtill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace COM3D2.EyeballControl.Plugin
{
    class EyeballControlGUI : MyGUI
    {
        public static int seleted;
        private static float h;
        private static float v;
        private static float s;
        private static bool isReverse;

        private static bool isOn;


        public override void Awake()
        {
            MaidActivePatch.selectionGrid2 += selectionGrid;
            //myWindowRect.WindowRectOpenH = 300f;
            EyeballControl.myLog.LogMessage("EyeballControlGUI.Awake", myWindowRect?.WindowRectOpen.h);
        }

        public override void Start()
        {
            EyeballControl.myLog.LogMessage("EyeballControlGUI.Start", myWindowRect?.WindowRectOpen.h);
            myWindowRect.WindowRectOpenH = 300f;
            EyeballControl.myLog.LogMessage("EyeballControlGUI.Start", myWindowRect?.WindowRectOpen.h);
        }

        public static void selectionGrid()
        {
            selectionGrid(seleted);
        }

        public static void selectionGrid(int seleted)
        {
            EyeballControl.myLog.LogMessage("EyeballControlGUI.selectionGrid", seleted);
            isOn = false;
            //EyeballControlUtill.selectedMaid = MaidActivePatch.GetMaid(seleted);
            if (MaidActivePatch.GetMaid(seleted)!=null&& EyeballControlUtill.maids.ContainsKey(seleted))
            {
                MaidEyesData m = EyeballControlUtill.maids[seleted];
                if (m.isCoroutine)
                {
                    return;
                }
                h = m.eyeRightLeft;
                v = m.eyeUpDown;
                s = m.eyeScale;
                isReverse = m.isReverse;
                isOn = true;
            }
            //else
            //{
            //}
        }
        /*
        */

        public override void WindowFunctionBody(int id)
        {
            //base.WindowFunctionBody(id);
            //GUI.enabled = maidEyesData != null;

            GUI.enabled = isOn;
            GUI.changed = false;


            GUILayout.BeginHorizontal();
            GUILayout.Label("↓", GUILayout.Width(20));
            v = GUILayout.HorizontalSlider(v, -0.2f, 0.2f);
            if (GUI.changed)
            {
                EyeballControlUtill.UpDown(v);
                GUI.changed = false;
            }
            GUILayout.Label("↑", GUILayout.Width(20));
            if (GUILayout.Button("R", GUILayout.Width(20)))
            {
                EyeballControlUtill.UpDown(0);
            }
            GUILayout.EndHorizontal();


            isReverse = GUILayout.Toggle(isReverse, "내부와 외부를 향하도록한다");
            if (GUI.changed)
            {
                EyeballControlUtill.RightLeft(isReverse);
                GUI.changed = false;
            }

            GUILayout.BeginHorizontal();
            GUILayout.Label("←", GUILayout.Width(20));
            h = GUILayout.HorizontalSlider(h, -0.2f, 0.2f);
            if (GUI.changed)
            {
                EyeballControlUtill.RightLeft(h);
                GUI.changed = false;
            }
            GUILayout.Label("→", GUILayout.Width(20));
            if (GUILayout.Button("R", GUILayout.Width(20)))
            {
                EyeballControlUtill.RightLeft(0);
            }
            GUILayout.EndHorizontal();


            GUILayout.BeginHorizontal();
            GUILayout.Label("-", GUILayout.Width(20));
            s = GUILayout.HorizontalSlider(s, -1f, 1f);
            if (GUI.changed)
            {
                EyeballControlUtill.Scale(s);
                GUI.changed = false;
            }
            GUILayout.Label("+", GUILayout.Width(20));
            if (GUILayout.Button("R", GUILayout.Width(20)))
            {
                EyeballControlUtill.Scale(0);
            }
            GUILayout.EndHorizontal();


            GUI.enabled = true;

            seleted = MaidActivePatch.SelectionGrid2(seleted);

        }

    }
}
