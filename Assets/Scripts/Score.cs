using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int score = 0;
    Text ScoreText;

    void Start()
    {
        ScoreText = GetComponent<Text>();
    }

    void Update()
    {
        ScoreText.text = "Score:" + score;
    }
}
