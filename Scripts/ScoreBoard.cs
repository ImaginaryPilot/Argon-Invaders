using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{

    int score = 0;
    Text scoretext;

    void Start()
    {
        scoretext = GetComponent<Text>();
        scoretext.text = score.ToString();
    }
    
    public void ScoreHit(int scorePerHit)
    {
        score = score + scorePerHit;
        scoretext.text = score.ToString();
    }
}
