using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public GameObject GameOverPanel;
    public GameObject ZigZagPanel;
    public GameObject tapText;
    public Text score;
    public Text highscore1;
    public Text highscore2;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        highscore1.text = "High Score : " + PlayerPrefs.GetInt("highScore").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GameStart()
    {
        
       
        ZigZagPanel.GetComponent<Animator>().Play("panelAnim");
        tapText.SetActive(false);
    }
    public void GameOver() 
    {
        score.text = PlayerPrefs.GetInt("score").ToString();
        highscore2.text = PlayerPrefs.GetInt("highScore").ToString();
        GameOverPanel.SetActive(true);

    }
    public void Reset()
    {
        SceneManager.LoadScene(0);
    }


}
