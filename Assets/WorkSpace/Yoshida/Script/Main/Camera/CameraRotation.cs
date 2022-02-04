using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public GameObject Player;                           //プレイヤー
    public GameObject Camera;                           //カメラ
    public GameObject LookPos;
    public float rotatespeed = 2.0f;
    public float rotatespeed2 = 0.1f;
    public float rotateMax = 4f;
    public float rotateMin = 0.1f;
    public Vector3 OffSet = new Vector3(0, 1.4f, 0);    //ターゲットの少し上
    public Vector3 CamDir = new Vector3(0, 2, -4.0f);   //ターゲットから見たカメラ方向
    Vector3 PlayerPos;                                  //プレイヤーの位置
    bool CameraMove;
    // Start is called before the first frame update
    void Start()
    {
        //カメラの位置。プレイヤー位置から算出する。
        Vector3 NewDir = Player.transform.TransformDirection(CamDir);
        Camera.transform.position = Player.transform.position + NewDir;

        //プレイヤーの位置を取得
        PlayerPos = Player.transform.position;

        LookPos.transform.position = Player.transform.position + OffSet;

        //カメラの回転。注視点はプレイヤーの少し上を見る。
        Camera.transform.LookAt(LookPos.transform.position);

        CameraMove = true;
    }

    //プレイヤーを軸にカメラを回転
    void rotateCamera()
    {
        if (CameraMove) //カメラ操作可能時
        {
            float angle = Input.GetAxis("Mouse X") * rotatespeed;

            float angle2 = Input.GetAxis("Mouse Y") * rotatespeed2;

            Vector3 playerPos = Player.transform.position;

            Camera.transform.RotateAround(playerPos, Vector3.up, angle);
            LookPos.transform.RotateAround(playerPos, Vector3.up, angle);

            Camera.transform.position -= new Vector3(0, angle2, 0);

            //カメラの上下向き
            if(Camera.transform.position.y <= rotateMin + playerPos.y)
            {
                Camera.transform.position = new Vector3(Camera.transform.position.x, rotateMin + playerPos.y, Camera.transform.position.z);
            }
            if (Camera.transform.position.y >= rotateMax + playerPos.y)
            {
                Camera.transform.position = new Vector3(Camera.transform.position.x, rotateMax + playerPos.y, Camera.transform.position.z);
            }


            Camera.transform.LookAt(LookPos.transform.position);
        }
    }

    void Ready()
    {
        CameraMove = false;
    }

    void Play()
    {
        CameraMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Player != null)
        {
            //プレイヤーに追従する
            Camera.transform.position += Player.transform.position - PlayerPos;
            LookPos.transform.position += Player.transform.position - PlayerPos;
            PlayerPos = Player.transform.position;

            rotateCamera();
        }
    }
}
