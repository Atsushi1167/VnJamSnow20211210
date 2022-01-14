using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    public Text txtNav;
    float Elapsed;

    // Start is called before the first frame update
    void Start()
    {
        Elapsed = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        Elapsed += Time.deltaTime;
        Elapsed %= 1.0f;
        txtNav.text = (Elapsed < 0.8f) ? "Push Any Button" : "";

        if(Input.anyKey)
        {
            SceneManager.LoadScene("RULE");
        }
    }
}
