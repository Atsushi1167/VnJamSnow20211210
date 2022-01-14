using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAction : MonoBehaviour
{
    Vector3 MustBePos; //自身が居るべき位置
    public GameObject WalkMarker; //次の移動先
    GameObject Marker; //設置したマーカー
    float walkSpeed = 1.0f; //歩く速度
    float Elapsed = 0.0f; //経過時間

    // Start is called before the first frame update
    void Start()
    {
        Elapsed = 0.0f; //経過時間リセット
    }

    public void OnHitMarker()
    {
            MustBePos = transform.position; //現在位置を移動先とする
            Elapsed = 0.0f;
    }

    //歩行システム
    void WalkSystem()
    {
        Elapsed += Time.deltaTime;
        if (Elapsed > 5.0f)
        { //5秒経過したら次の行き先を作る
            Elapsed = 0.0f;
            Destroy(Marker); //前マーカーがあれば削除
                             //マーカー座標を生成
            Vector3 StartPos = transform.position + Vector3.up;
            Vector3 TargetPos = StartPos;
            float Theta = Random.Range(0, Mathf.PI * 2.0f);
            TargetPos.x += Mathf.Cos(Theta) * 5.0f;
            TargetPos.z += Mathf.Sin(Theta) * 5.0f;
            Marker = Instantiate(WalkMarker, TargetPos, Quaternion.identity); //マーカーを設置
            Vector3 WalkDir = TargetPos - StartPos; //歩く方向を算出
            Ray WalkRay = new Ray(StartPos, WalkDir); //歩く方向にRayを飛ばす
            Debug.DrawRay(StartPos, WalkDir, Color.yellow, 4.0f); //Rayを視覚化
            RaycastHit hitInfo;
            if (Physics.Raycast(WalkRay, out hitInfo))
            {
                if (hitInfo.collider.gameObject == Marker)
                {
                    //設置マーカーにRayが当たれば見える位置なので目的地とする
                    MustBePos = Marker.transform.position;
                    MustBePos.y = 0.0f;
                    transform.LookAt(MustBePos); //目的地を向く
                }
                else
                {
                    Destroy(Marker);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        WalkSystem();
        Vector3 Dir = MustBePos - transform.position;
        transform.position += Dir.normalized * walkSpeed * Time.deltaTime;
    }
}
