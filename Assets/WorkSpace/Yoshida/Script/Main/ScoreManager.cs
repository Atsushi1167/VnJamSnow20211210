using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    int score;
    public Text txtScore;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        txtScore.text = "SCORE : " + score.ToString("D8");
    }

    public void ScorePulse()
    {
        score += 500;
        txtScore.text = "SCORE : " + score.ToString("D8");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
