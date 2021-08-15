using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace COM3D2.EyeballControl.Plugin
{
    /*
    class EyeballControlPatch
    {
        public static FaceWindow faceWindow;
        public static PlacementWindow placementWindow;

        [HarmonyPatch(typeof(FaceWindow), "Awake")]
        [HarmonyPostfix]// CharacterMgr의 SetActive가 실행 후에 아래 메소드 작동
        public static void FaceWindow_Awake(FaceWindow __instance)
        {
            faceWindow = __instance;
            //faceWindow.CheckBoxFaceToCamera.onClick.Add(onCheckAction);
            //faceWindow.CheckBoxEyeToCamera.onClick.Add(onCheckAction);
        }

        [HarmonyPatch(typeof(PlacementWindow), "Awake")]
        [HarmonyPostfix]// CharacterMgr의 SetActive가 실행 후에 아래 메소드 작동
        public static void PlacementWindow_Awake(PlacementWindow __instance)
        {
            placementWindow = __instance;
            //EventDelegate.Add(placementWindow.DeActiveButton.onClick, onClickDeActiveAction);
        }

    }
    */
}
