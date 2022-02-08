using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    private PlayerScript Parent;
    float h, v;         //入力の垂直軸,水平軸の数値
    Animator myAnim;    //自身のアニメーター
    bool CanMove;
    public bool CanJump;
    AudioSource MyAudio;
    public bool isMove;
    public bool isDash;
    public AudioClip SE_WALK;
    public AudioClip SE_DASH;

    // Start is called before the first frame update
    void Start()
    {
        Parent = this.transform.parent.gameObject.GetComponent<PlayerScript>();
        myAnim = GetComponent<Animator>(); //自身のアニメーターを取得
        ReadyAnim();
        MyAudio = GetComponent<AudioSource>();
        isMove = false;
        isDash = false;
    }

    //歩く・走る
    void WalkAndRun()
    {
        if (CanMove)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                h = Input.GetAxis("Horizontal"); //入力デバイスの水平軸
                v = Input.GetAxis("Vertical"); //入力デバイスの垂直軸
                h = h * 2.0f;
                v = v * 2.0f;
            }
            else
            {
                h = Input.GetAxis("Horizontal"); //入力デバイスの水平軸
                v = Input.GetAxis("Vertical"); //入力デバイスの垂直軸
            }
            myAnim.SetFloat("AD", h);
            myAnim.SetFloat("WS", v);
        }
    }

    public void ReadyAnim()
    {
        CanMove = false;
        myAnim.SetBool("isMove",false);
    }

    public void PlayAnim()
    {
        CanMove = true;
        myAnim.SetBool("isMove", true);
    }

    public void OnGround()
    {
        myAnim.SetBool("Jump", false);
    }

    public void Throw()
    {
        myAnim.SetTrigger("Throw");
    }

    // Update is called once per frame
    void Update()
    {
        CanJump = Parent.CanJump;
        WalkAndRun();
        if (CanJump)
        {
            myAnim.SetBool("Jump", false);
        }
        else
        {
            myAnim.SetBool("Jump", true);
        }

        //if(h > 1.8f || v > 1.8f || h < -1.8f || v < -1.8f)
        //{
        //    isDash = true;
        //}
        //else if(h > 0.8f || v > 0.8f || h < -0.8f || v < -0.8f)
        //{
        //    isMove = true;
        //    isDash = false;
        //}
        //else
        //{
        //    isDash = false;
        //    isMove = false;
        //}

        //if (isDash)
        //{
        //    MyAudio.clip = SE_DASH;
        //}
        //else if (isMove)
        //{
        //    MyAudio.clip = SE_WALK;
        //}
        //else
        //{
        //    MyAudio.clip = null;
        //}
    }
}
