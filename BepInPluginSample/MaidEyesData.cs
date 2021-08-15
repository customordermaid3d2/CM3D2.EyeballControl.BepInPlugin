using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace COM3D2.EyeballControl.Plugin
{
    class MaidEyesData
    {
        //const string STORE_KEY_FACE_TO_CAMERA = "face_to_camera";
        //const string STORE_KEY_EYE_TO_CAMERA = "eye_to_camera";

        public Maid maid { get; private set; }
        //public string name { get; private set; }

        public bool isReverse { get; set; }

        public float eyeUpDown { get; set; }

        public float eyeRightLeft { get; set; }

        public float eyeScale { get; set; }

        public bool enabled { get; private set; }


        //bool faceToCamera => stringToBool(_storeData[STORE_KEY_FACE_TO_CAMERA]);

        //bool eyeToCamera => stringToBool(_storeData[STORE_KEY_EYE_TO_CAMERA]);

        // FaceWindow _faceWindow;

        EData _dataLeft;
        EData _dataRight;
        public bool isCoroutine;

        //Dictionary<string, string> _storeData;

        struct EData
        {
            public Quaternion def;

            public Quaternion current;

            public Vector3 scale;


            public EData(Maid maid_, bool isLeft_)
            {             

                
                if (isLeft_ == true)
                {
                    def = maid_.body0.quaDefEyeL;
                    scale = maid_.body0.trsEyeL.localScale;
                }
                else
                {
                    def = maid_.body0.quaDefEyeR;
                    scale = maid_.body0.trsEyeR.localScale;
                }

                current = def;
            }

        }


        public MaidEyesData(Maid maid_)//, FaceWindow faceWindow_)
        {
            maid = maid_;
            //name = maid.status.charaName.GetFullName();

            EyeballControl.instance.StartCoroutine(MyCoroutine());

            //_storeData = EyeballControlPatch.faceWindow.GetMaidStoreData(maid);

            //_faceWindow = faceWindow_;
        }

        public IEnumerator MyCoroutine()
        {
            isCoroutine = true;
            while (!maid.body0.isLoadedBody)
            {

                //yield return null;
                yield return new WaitForSeconds(.5f);
            }

            _dataLeft = new EData(maid, true);
            _dataRight = new EData(maid, false);

            isCoroutine = false;
            EyeballControlGUI.selectionGrid();
        }


        /*
        public void SetEnabled()
        {
            enabled = faceToCamera == false && eyeToCamera == false;

            if (enabled == false)
            {
                Reset();
            }
        }
        public void ForceEnabled()
        {
            if (faceToCamera == true)
            {
                EyeballControlPatch.faceWindow.CheckBoxFaceToCamera.Button.onClick[0].Execute();
            }

            if (eyeToCamera == true)
            {
                EyeballControlPatch.faceWindow.CheckBoxEyeToCamera.Button.onClick[0].Execute();
            }

            enabled = true;
        }

        */

        public void UpDown(float val_)
        {
            _dataLeft.current = calcQuaternionAddZ(_dataLeft, val_ * -1);
            _dataRight.current = calcQuaternionAddZ(_dataRight, val_);

            eyeUpDown = val_;

            setQuaternion();
        }

        public void RightLeft(float val_)
        {
            _dataLeft.current = calcQuaternionAddY(_dataLeft, val_ * -1);
            _dataRight.current = calcQuaternionAddY(_dataRight, val_ * (isReverse == false ? 1 : -1));

            eyeRightLeft = val_;

            setQuaternion();
        }

        public void Scale(float val_)
        {
            maid.body0.trsEyeL.localScale = calcEyeScale(_dataLeft, val_);
            maid.body0.trsEyeR.localScale = calcEyeScale(_dataRight, val_);

            eyeScale = val_;
        }

        public void Reset()
        {
            UpDown(0);
            RightLeft(0);
            Scale(0);

            isReverse = false;

            enabled = false;
        }

        //bool stringToBool(string str_) => bool.Parse(str_);

        Quaternion calcQuaternionAddY(EData val_, float y_) => new Quaternion(val_.current.x, val_.def.y + y_, val_.current.z, val_.current.w);

        Quaternion calcQuaternionAddZ(EData val_, float z_) => new Quaternion(val_.current.x, val_.current.y, val_.def.z + z_, val_.current.w);

        Vector3 calcEyeScale(EData data_, float val_) => new Vector3(data_.scale.x, data_.scale.y + val_, data_.scale.z + val_);

        void setQuaternion()
        {
            maid.body0.quaDefEyeL = _dataLeft.current;
            maid.body0.quaDefEyeR = _dataRight.current;
        }

    }
}
