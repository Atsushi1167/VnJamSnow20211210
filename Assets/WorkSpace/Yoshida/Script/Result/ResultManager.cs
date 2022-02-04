using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultManager : MonoBehaviour
{
    public Text txtNav;
    public Image imgFill;
    public Text[] txtRank;

    float Elapsed = 0.0f;
    float LongPush = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        for (int idx = 1; idx <= 5; idx++)
        {
            if (PlayerPrefs.GetInt("R" + idx) <= 0)
            {
                txtRank[idx - 1].text = "________";
            }
            else
            {
                txtRank[idx - 1].text = PlayerPrefs.GetInt("R" + idx).ToString("D8");
            }
        }
    }

    void Score()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //メッセージの点滅
        Elapsed += Time.deltaTime;
        Elapsed %= 1.0f;
        txtNav.text = (Elapsed < 0.8f) ? "Push Left Mouse Button" : "";

        //長押し検出
        if (Input.GetButton("Fire1"))
        {
            LongPush += Time.deltaTime;
            if (LongPush > 3.0f)
            {
                SceneManager.LoadScene("TITLE");
            }
        }
        else
        {
            LongPush = 0.0f;
        }

        //長押しリング
        imgFill.fillAmount = LongPush / 3.0f;

        ////開発用：データ領域の初期化
        //if (Input.GetKeyDown(KeyCode.Escape))
        //{
        //    PlayerPrefs.DeleteAll();
        //    Debug.Log("データ領域を削除しました。");
        //}
    }
}