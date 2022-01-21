﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameObject Camera;               //カメラ
    public float movespeed = 3.0f;          //プレイヤーの歩行速度
    public float dashspeed = 7.0f;          //プレイヤーのダッシュ速度
    public float ThrowcoolTime = 1.0f;      //雪玉の連射クールタイム

    private bool CanMove;                   //走れるか?
    public bool CanJump;                    //ジャンプできるか?
    public bool CanThrow;                   //投げられるか?

    private float Elapsed;                  //時間計測用
    private float Elapsed2;                 //クールタイムの計測用

    Vector3 DefaultPos;                     //プレイヤーの初期位置

    float inputHorizontal;
    float inputVertical;

    Rigidbody rigid;

    // Start is called before the first frame update
    void Start()
    {
        this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);   //照準角度を初期化
        this.rigid = GetComponent<Rigidbody>();                         //自身のRigidbodyを取得
        CanMove = false;
        CanJump = false;
        CanThrow = false;
        Elapsed = 0.0f;
        Elapsed2 = 0.0f;
        DefaultPos = transform.position;                                //初期位置を保存
    }

    private void OnCollisionStay(Collision other)
    {
        //空中に浮いている間ステージオブジェクトに触れる(移動:不可)
        if (other.gameObject.tag == "Stage" && !CanJump)
        {
            CanMove = false;
        }
        //地面にいる間(移動:可/ジャンプ:可)
        if (other.gameObject.tag == "Ground")
        {
            CanJump = true;
            gameObject.GetComponent<Animation>().OnGround();
        }
    }

    private void OnCollisionExit(Collision other)
    {
        //地面から離れる(ジャンプ:不可)
        if (other.gameObject.tag == "Ground")
        {
            CanJump = false;
        }
    }

    public void Ready()
    {
        CanMove = false;
    }

    public void Play()
    {
        CanMove = true;
    }

    //プレイヤーにカメラの正面方向を向かせる
    void LookFront()
    {
        Vector3 Campos = Camera.transform.position;
        Vector3 target = this.transform.position;
        target.x = target.x * 2 - Campos.x;
        target.z = target.z * 2 - Campos.z;
        this.transform.LookAt(target);
    }

    //プレイヤーを初期位置に戻す
    void RestPlayerPos()
    {
        this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        transform.position = DefaultPos;
    }

    //雪玉を投げる
    void Throw()
    {
        if (Input.GetButton("Fire1") && CanThrow)
        {
            LookFront();
            CanThrow = false;
        }
        if (!CanThrow)
        {
            Elapsed2 += Time.deltaTime;
            if (Elapsed2 > ThrowcoolTime)
            {
                CanThrow = true;
                Elapsed2 = 0.0f;
            }
        }
    }

    private void Update()
    {
        //スティックの傾きを取得(未実装)
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");

        //プレイヤー操作可能時
        if (CanMove)
        {
            if (Input.GetKeyDown(KeyCode.Space) && CanJump)         //Spaceでジャンプ
            {
                rigid.AddForce(new Vector3(0, 6.0f, 0), ForceMode.Impulse);
            }

            Throw();
        }


        //空中から戻れなくなった時位置をリセットする
        //if(!CanJump)
        //{
        //    Elapsed += Time.deltaTime;
        //    if(Elapsed > 30.0f)
        //    {
        //        RestPlayerPos();
        //        Elapsed = 0.0f;
        //    }
        //}
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Transform myTransform = this.transform;             //自身の座標を取得

        float timespeed = movespeed * Time.deltaTime;       //移動速度*押されている時間

        if (CanMove)
        {
            if (Input.GetKey(KeyCode.LeftShift))                 //ダッシュしている
            {
                timespeed = dashspeed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.W))                        //Wキーで前進
            {
                LookFront();
                transform.localPosition += transform.forward * timespeed;
            }
            if (Input.GetKey(KeyCode.A))                        //Aキーで左に移動
            {
                LookFront();
                transform.localPosition -= transform.right * timespeed;
            }
            if (Input.GetKey(KeyCode.S))                        //Sキーで後退
            {
                LookFront();
                transform.localPosition -= transform.forward * timespeed;
            }
            if (Input.GetKey(KeyCode.D))                        //Dキーで右に移動
            {
                LookFront();
                transform.localPosition += transform.right * timespeed;
            }
        }
    }
   
}
