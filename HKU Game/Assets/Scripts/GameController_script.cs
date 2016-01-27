using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController_script : MonoBehaviour {

    public Text scoreText;
    public int score;
    public int highscore;
    private GameObject[] bugs;

    void Start()
    {
        DontDestroyOnLoad(this);
        score = 0;
        PlayerPrefs.SetInt("HighScore", 0);
        UpdateScore();
        bugs = GameObject.FindGameObjectsWithTag("Bug");
        BugPenalty();
    }

   

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
        highscore = score;
        if(highscore > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", highscore);
        }
        Debug.Log(PlayerPrefs.GetInt("HighScore"));
    }

    void OnGUI()
    {
        if (SceneManager.GetActiveScene().buildIndex ==2 || SceneManager.GetActiveScene().buildIndex == 1)
        {
            GUI.TextArea(new Rect(Screen.width/2 -100, 20, 200, 20), "Score: " + PlayerPrefs.GetInt("HighScore")  );
        }
    }

    public void BugPenalty()
    {
        foreach (GameObject bug in bugs)
        {
            AddScore(-150);
            Debug.Log("-150");
        }
    }

}
