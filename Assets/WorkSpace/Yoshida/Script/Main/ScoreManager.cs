using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    int score;
    public Text txtScore;
    public Text txtDouble;
    int[] Rank = new int[6]; // 作業エリア
    public bool Double;
    float Elapsed;
    public float Doubletime = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        txtScore.text = "SCORE : " + score.ToString("D8");
        txtDouble.text = "";
        Double = false;
        Elapsed = 0.0f;

        // アプリのデータ領域が存在するか
        if (PlayerPrefs.HasKey("R1"))
        {
            Debug.Log("データ領域を読み込みました。");
            for (int idx = 1; idx <= 5; idx++)
            {
                Rank[idx] = PlayerPrefs.GetInt("R" + idx); // データ領域読み込み
            }
        }
        else
        {
            Debug.Log("データ領域を初期化しました。");
            for (int idx = 1; idx <= 5; idx++)
            {
                Rank[idx] = 0;
                PlayerPrefs.SetInt("R" + idx, 0); // 最大値を格納する
            }
        }
    }

    public void ScorePulse()
    {
        if (Double)
        {
            score += 500 * 2;
        }
        else
        {
            score += 500;
        }
        txtScore.text = "SCORE : " + score.ToString("D8");
    }

    public void DoubleScore()
    {
        Double = true;
    }

    public void SetRank()
    {
        int newRank = 0; //まず今回のタイムを0位と仮定する
        for (int idx = 5; idx > 0; idx--)
        { //逆順 5...1
            if (Rank[idx] < score)
            { 
                newRank = idx; // 新しいランクとして判定する
            }
        }
        if (newRank != 0)
        { // 0位のままでなかったらランクイン確定
            for (int idx = 5; idx > newRank; idx--)
            { 
                Rank[idx] = Rank[idx - 1]; // 繰り下げ処理
            }
            Rank[newRank] = score; // 新ランクに登録
            for (int idx = 1; idx <= 5; idx++)
            {
                PlayerPrefs.SetInt("R" + idx, Rank[idx]); // データ領域に保存
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Double)
        {
            txtDouble.text = "X2";
            Elapsed += Time.deltaTime;
            if(Elapsed > Doubletime)
            {
                Double = false;
                Elapsed = 0.0f;
                txtDouble.text = "";
            }
        }
    }
}
