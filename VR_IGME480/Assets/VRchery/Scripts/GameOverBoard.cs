using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverBoard : MonoBehaviour
{
    private int score;
    private int highScore;
    private bool scoreChanged;
    private GameObject SCORE;
    private GameObject HIGHSCORE;
    private Text highscoreText;
    private Text scoreText;
    private float timeLeft;
    private string text;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("HiScore") == 0)
        {
            PlayerPrefs.SetInt("HiScore", 5);
        }
        timeLeft = 90f;
        score = 0;
        scoreChanged = false;
        SCORE = GameObject.FindGameObjectWithTag("SCORE");
        scoreText = SCORE.GetComponent<Text>();
        HIGHSCORE = GameObject.FindGameObjectWithTag("HIGHSCORE");
        highscoreText = HIGHSCORE.GetComponent<Text>();
        score = PlayerPrefs.GetInt("SessionScore");
        highScore = PlayerPrefs.GetInt("HiScore");
        scoreText.text = "Score: " + score;
        highscoreText.text = "Highscore: " + highScore;

    }
}
