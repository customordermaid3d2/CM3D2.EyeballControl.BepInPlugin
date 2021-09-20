using COM3D2.LillyUtill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using UnityEngine;

namespace COM3D2.EyeballControl.Plugin
{
    class EyeballControlUtill
    {
        public static Dictionary<int, MaidEyesData> maids = new Dictionary<int, MaidEyesData>();

        internal static void init()
        {
            MaidActivePatch.setActiveMaid3 += setActiveMaid;
            MaidActivePatch.deactivateMaid += deactivateMaid;
            foreach (var item in MaidActivePatch.Maids2)
            {
                setActiveMaid(item.Key, item.Value);
            }
        }

        internal static void deinit()
        {
            MaidActivePatch.setActiveMaid3 -= setActiveMaid;
            MaidActivePatch.deactivateMaid -= deactivateMaid;
            maids.Clear();
        }

        private static void setActiveMaid(int obj, Maid maid)
        {
            if (maids.ContainsKey(obj))
            {
                maids[obj] = new MaidEyesData( maid);
            }
            else
            {
                maids.Add(obj, new MaidEyesData(maid));
            }
            EyeballControlGUI.selectionGrid();
        }

        private static void deactivateMaid(int obj)
        {
            maids.Remove(obj);
            EyeballControlGUI.selectionGrid();
        }

        internal static void UpDown(float v)
        {
            maids[EyeballControlGUI.seleted]?.UpDown(v);
        }

        internal static void RightLeft(bool isReverse)
        {
            var maid = maids[EyeballControlGUI.seleted];
            if (maid!=null)
            {
                maid.isReverse = isReverse;
                maids[EyeballControlGUI.seleted]?.UpDown(maid.eyeRightLeft);
            }
        }
    
        internal static void RightLeft(float h)
        {
            maids[EyeballControlGUI.seleted]?.RightLeft(h);
        }

        internal static void Scale(float s)
        {
            var maid = maids[EyeballControlGUI.seleted];
            if (maid != null)
            {
                maid.Scale(s);
            }

        }

    }

}
