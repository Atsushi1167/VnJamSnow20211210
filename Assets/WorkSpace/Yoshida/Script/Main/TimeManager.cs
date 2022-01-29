using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour
{
    GameObject Player;
    GameObject PlayerAnim;
    GameObject[] Enemies;
    float ThreeCount = 3.0f;
    public float Limit = 60.0f;
    float Count;
    float Elapsed;
    public int PlayerHP;

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
    public GameObject imgCrosshair;
    public Text txtHP;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        PlayerAnim = GameObject.FindWithTag("Animator");
        Enemies = GameObject.FindGameObjectsWithTag("Enemey");
        foreach (GameObject Enemy in Enemies)
        {
            Enemy.GetComponent<EnemyAction>().AIOnOff(false);
        }
        SetStart();
    }

    void SetStart()
    {
        GameMode = MODE.ThreeCount;
        ThreeCount = 3.0f;
        Count = Limit;
        Elapsed = 0.0f;
        txtThreeCount.text = Count.ToString("N2");
        txtLimit.text = "";
        imgCrosshair.SetActive(false);
        txtHP.text = "";
        PlayerHP = 0;
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
                PlayerHP = Player.GetComponent<PlayerHP>().GetHP();
                if (ThreeCount <= 0.0f)
                {
                    txtThreeCount.text = "START!";
                }
                if(ThreeCount < -1.5f)
                {
                    GameMode = MODE.Main;

                    //プレイヤーを操作可能に
                    Player.GetComponent<PlayerScript>().Play();
                    PlayerAnim.GetComponent<Animation>().PlayAnim();
                }

                break;

            case MODE.Main:
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                foreach (GameObject Enemy in Enemies)
                {
                    Enemy.GetComponent<EnemyAction>().AIOnOff(true);
                }
                if (PlayerHP > 0)
                {
                    txtThreeCount.text = "";
                    Count -= Time.deltaTime;
                    txtLimit.text = Count.ToString("N0") + "s";
                    PlayerHP = Player.GetComponent<PlayerHP>().GetHP();
                    txtHP.text = "HP:" + PlayerHP;
                    imgCrosshair.SetActive(true);
                }
                else
                {
                    Elapsed += Time.deltaTime;
                    imgCrosshair.SetActive(false);
                    txtLimit.text = "";
                    txtHP.text = "";
                    txtThreeCount.text = "GameOver!";
                    if (Elapsed > 1.5f)
                    {
                        GameMode = MODE.GameOver;
                    }
                }

                if (Count <= 0.0f)
                {
                    imgCrosshair.SetActive(false);
                    txtLimit.text = "";
                    txtHP.text = "";
                    txtThreeCount.text = "GameSet!";
                    foreach (GameObject Enemy in Enemies)
                    {
                        Enemy.GetComponent<EnemyAction>().AIOnOff(false);
                    }
                    //プレイヤーを操作不可に
                    Player.GetComponent<PlayerScript>().Ready();
                    PlayerAnim.GetComponent<Animation>().ReadyAnim();
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
