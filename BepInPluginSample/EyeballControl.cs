using BepInEx;
using BepInEx.Configuration;
using COM3D2.LillyUtill;
using COM3D2API;
using HarmonyLib;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace COM3D2.EyeballControl.Plugin
{
    class MyAttribute
    {
        public const string PLAGIN_NAME = "EyeballControl";
        public const string PLAGIN_VERSION = "21.8.15";
        public const string PLAGIN_FULL_NAME = "COM3D2.EyeballControl.BepInPlugin";
    }

    [BepInPlugin(MyAttribute.PLAGIN_FULL_NAME, MyAttribute.PLAGIN_NAME, MyAttribute.PLAGIN_VERSION)]// 버전 규칙 잇음. 반드시 2~4개의 숫자구성으로 해야함. 미준수시 못읽어들
    [BepInProcess("COM3D2x64.exe")]
    public class EyeballControl : BaseUnityPlugin
    {
        // 단축키 설정파일로 연동
        //private ConfigEntry<BepInEx.Configuration.KeyboardShortcut> ShowCounter;

       // Harmony harmony;

        public static EyeballControl instance;

        public static MyLog myLog = new MyLog(MyAttribute.PLAGIN_NAME);

        public EyeballControl()
        {
            instance = this;
        }


        /// <summary>
        ///  게임 실행시 한번만 실행됨
        /// </summary>
        public void Awake()
        {
            EyeballControl.myLog.LogMessage("Awake",MyUtill.Get_BuildDateTime(System.Reflection.Assembly.GetExecutingAssembly().GetName().Version));

            EyeballControlUtill.init();

            // 단축키 기본값 설정
            //ShowCounter = Config.Bind("KeyboardShortcut", "KeyboardShortcut0", new BepInEx.Configuration.KeyboardShortcut(KeyCode.Alpha9, KeyCode.LeftControl));

            //SampleConfig.Install(EyeballControl.myLog.log);            

        }       

        /*
        public void OnEnable()
        {
            EyeballControl.myLog.LogMessage("OnEnable");

            //SceneManager.sceneLoaded += this.OnSceneLoaded;

            // 하모니 패치
            //harmony = Harmony.CreateAndPatchAll(typeof(EyeballControlPatch));

        }
        */

        /// <summary>
        /// 게임 실행시 한번만 실행됨
        /// </summary>
        public void Start()
        {
            EyeballControl.myLog.LogMessage("Start");

            EyeballControlGUI.Install<EyeballControlGUI>(gameObject, Config, MyAttribute.PLAGIN_FULL_NAME, MyAttribute.PLAGIN_NAME, "EC", COM3D2.EyeballControl.Plugin.Properties.Resources.icon, new BepInEx.Configuration.KeyboardShortcut(KeyCode.Alpha9, KeyCode.LeftControl));
        }

        /*
        public void OnDisable()
        {
            EyeballControl.myLog.LogMessage("OnDisable");

            //SceneManager.sceneLoaded -= this.OnSceneLoaded;

            //harmony?.UnpatchSelf();// ==harmony.UnpatchAll(harmony.Id);
            //harmony.UnpatchAll(); // 정대 사용 금지. 다름 플러그인이 패치한것까지 다 풀려버림
        }
        */
    }
}
