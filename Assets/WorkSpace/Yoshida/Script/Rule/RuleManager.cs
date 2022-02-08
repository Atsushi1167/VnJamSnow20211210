using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RuleManager : MonoBehaviour
{
    public Text txtNav;
    public Image imgFill;

    float Elapsed = 0.0f;
    float LongPush = 0.0f;
    float Elapsed2 = 0.0f;
    AudioSource MyAudio;
    public AudioClip SE_Click;
    bool start;

    // Start is called before the first frame update
    void Start()
    {
        MyAudio = GetComponent<AudioSource>();
        start = false;
    }

    // Update is called once per frame
    void Update()
    {
        //メッセージの点滅
        Elapsed += Time.deltaTime;
        Elapsed %= 1.0f;
        txtNav.text = (Elapsed < 0.8f) ? "Push Left Mouse Button" : "";

        //長押し検出
        if (Input.GetButton("Fire1") && !start)
        {
            LongPush += Time.deltaTime;
            if (LongPush > 3.0f)
            {
                start = true;
            }
        }
        else
        {
            LongPush = 0.0f;
        }

        if(start)
        {
            SceneManager.LoadScene("Main");
        }

        //長押しリング
        imgFill.fillAmount = LongPush / 3.0f;
    }
}
