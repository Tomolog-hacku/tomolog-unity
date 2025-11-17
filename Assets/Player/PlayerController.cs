using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 3.0f;  //移動スピード
    
    //アニメーション名
    /*public string upAnime = "PlayerUp";
    public string downAnime = "PlayerDown";
    public string rightAnime = "PlayerRight";
    public string leftAnime = "PlayerLeft";

    string nowAnimation = "";   //現在のアニメーション
    string oldAnimation = "";   //以前のアニメーション*/

    float axisH;    //横軸
    float axisV;    //縦軸
    //public float angleZ = -90.0f;   //回転角

    Rigidbody2D rbody;
    bool isMoving = false;

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        //oldAnimation = downAnime;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving == false)
        {
            axisH = Input.GetAxisRaw("Horizontal"); //左右キー入力
            axisV = Input.GetAxisRaw("Vertical");   //上下キー入力
        }

        //キー入力から移動角度を求める
        /*Vector2 fromPt = transform.position;
        Vector2 toPt = new Vector2(fromPt.x + axisH, fromPt.y + axisV);
        angleZ = GetAngle(fromPt, toPt);
        
        //移動方向から向いている方向とアニメション更新
        if (angleZ >= -45 && angleZ < 45)
        {   //右向き
            nowAnimation = rightAnime;
        } else if (angleZ >= 45 && angleZ <= 135)
        {
            //上向き
            nowAnimation = upAnime;
        } else if (angleZ >= -135 && angleZ <= -45)
        {
            //下向き
            nowAnimation = downAnime;
        } else
        {
            //左向き
            nowAnimation = leftAnime;
        }
        //アニメーションを切り替える
        if (nowAnimation != oldAnimation)
        {
            oldAnimation = nowAnimation;
            GetComponent<Animation>().Play(nowAnimation);
        }*/
    }

    void FixedUpdate()
    {
        //移動速度を更新する
        rbody.velocity = new Vector2(axisH, axisV).normalized * speed;
    }

    public void SetAxis(float h, float v)
    {
        axisH = h;
        axisV = v;
        if (axisH == 0 && axisV == 0)
        {
            isMoving = false;
        }
        else
        {
            isMoving = true;
        }
    }

    //p1からp2の角度を返す
    /*float GetAngle(Vector2 p1, Vector2 p2)
    {
        float angle;
        if (axisH != 0 || axisV != 0)
        {
            //移動中であれば角度を更新する
            //p1からp2への差分（原点を0にするため）
            float dx = p2.x - p1.x;
            float dy = p2.y - p1.y;

            //アークタンジェント2関数で角度（ラジアン）を求める
            float rad = Mathf.Atan2(dy, dx);
            //ラジアンを度に変換して返す
            angle = rad * Mathf.Rad2Deg;
        }
        else
        {
            //停止中であれば現在の角度を維持
            angle = angleZ;
        }
        return angle;
    }*/
}
