using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    private int score;
    private int highScore;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void IncrementScore()
    {
        score += 1;
        PlayerPrefs.SetInt("score", score);
    }
    public void StartScore()
    {
        InvokeRepeating("IncrementScore", 0.2f, 0.5f);
    }
    public void StopScore()
    {
        CancelInvoke("IncrementScore");
        PlayerPrefs.SetInt("score", score);
        if (PlayerPrefs.HasKey("highScore"))
        {
            if (score > PlayerPrefs.GetInt("highScore"))
            {
                PlayerPrefs.SetInt("highScore",score);
            }
        }
        else 
        {
            PlayerPrefs.SetInt("highScore",score);
        }
    }
}
