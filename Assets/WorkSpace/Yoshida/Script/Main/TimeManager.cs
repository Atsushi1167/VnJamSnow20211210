using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour
{
    float ThreeCount = 3.0f;
    public float Limit = 60.0f;
    float Count;

    enum MODE
    {
        ThreeCount,
        Main,
        GameOver,
        GameSet
    }

    MODE GameMode;

    public Text txtThreeCount;
    public Text txtLimit;

    // Start is called before the first frame update
    void Start()
    {
        SetStart();
    }

    void SetStart()
    {
        GameMode = MODE.ThreeCount;
        ThreeCount = 3.0f;
        Count = Limit;
        txtThreeCount.text = Count.ToString("N2");
        txtLimit.text = "";
    }

    void GameOver()
    {
        GameMode = MODE.GameOver;
    }

    // Update is called once per frame
    void Update()
    {
        switch(GameMode)
        {
            case MODE.ThreeCount:
                txtThreeCount.text = ThreeCount.ToString("N2");
                ThreeCount -= Time.deltaTime;
                if(ThreeCount <= 0.0f)
                {
                    txtThreeCount.text = "START!";
                }
                if(ThreeCount < -1.5f)
                {
                    GameMode = MODE.Main;
                }

                break;

            case MODE.Main:
                txtThreeCount.text = "";
                Count -= Time.deltaTime;
                txtLimit.text = Count.ToString("N0") + "s";

                if(Count <= 0.0f)
                {
                    txtLimit.text = "";
                    txtThreeCount.text = "GameSet!";
                }
                if (Count < -1.5f)
                {
                    GameMode = MODE.GameSet;
                }

                break;

            case MODE.GameSet:
                SceneManager.LoadScene("RESULT");
                break;

            case MODE.GameOver:
                SceneManager.LoadScene("GAMEOVER");
                break;
        }
    }
}
