using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour
{
    //HingiJointコンポーネントを入れる
    private HingeJoint myHingeJoint;

    //初期の傾き
    private float defaultAngle = 20;
    //弾いた時の傾き
    private float flickAngle = -20;
    bool a = false;
    // Use this for initialization
    void Start()
    {
        //HingeJointコンポーネント取得
        this.myHingeJoint = GetComponent<HingeJoint>();

        //フリッパーの傾きを設定
        SetAngle(this.defaultAngle);
    }

    void Update()
    {
        if (a == true)
        {
            SetAngle(this.flickAngle);

        }else{ SetAngle(this.defaultAngle); }
    }
    //左矢印キーを押した時左フリッパーを動かす
    public void LButtonDown()
    {
            a = true;
    }
    //右矢印キーを押した時右フリッパーを動かす
     public void RButtonDown()
      {
          a = true;
    }

    //矢印キー離された時フリッパーを元に戻す
    public void LButtonUp()
  {
           a = false;
  }
       public void RButtonUp()
     {
           a = false;
     }


    //フリッパーの傾きを設定
    public void SetAngle(float angle)
    {
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }
}