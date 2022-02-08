using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    public Text txtNav;
    float Elapsed;
    float Elapsed2;
    AudioSource MyAudio;
    public AudioClip SE_Click;
    bool start;

    // Start is called before the first frame update
    void Start()
    {
        Elapsed = 0.0f;
        Elapsed2 = 0.0f;
        MyAudio = GetComponent<AudioSource>();
        start = false;
    }

    // Update is called once per frame
    void Update()
    {
        Elapsed += Time.deltaTime;
        Elapsed %= 1.0f;
        txtNav.text = (Elapsed < 0.8f) ? "Push Any Button" : "";

        if(Input.anyKey && !start)
        {
            MyAudio.PlayOneShot(SE_Click);
            start = true;
        }
        if(start)
        {
            Elapsed2 += Time.deltaTime;
            if (Elapsed2 > 0.5f)
            {
                SceneManager.LoadScene("RULE");
            }
        }
    }
}
