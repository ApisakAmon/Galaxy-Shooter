using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{

    public Image LivesImageDisplay;
    public Sprite[] Lives;

    public Text ScoreText, BestText;
    public int Score, BestScore;

    private void Start()
    {
        BestScore = PlayerPrefs.GetInt("HighScore", 0);
        BestText.text = "Best: " + BestScore;
    }

    public GameObject TitleScreen;
    public void UpdateLives(int currentLives)
    {
        LivesImageDisplay.sprite = Lives[currentLives];
    }

    public void UpdateScores()
    {
        Score += 10;
        ScoreText.text = "Score: " + Score;
    }

    public void BestScoreCheck()
    {
        if (Score > BestScore)
        {
            BestScore = Score;
            BestText.text = "Best: " + BestScore;
            PlayerPrefs.SetInt("HighScore", BestScore);
        }
    }

    public void ShowTitleScreen()
    {
        TitleScreen.SetActive(true);
        ScoreText.text = "Score: ";
        Score = 0;
    }

    public void HintTitleScreen()
    {
        TitleScreen.SetActive(false);
    }

    public void ResumePlay()
    {
        GameManager gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        gm.ResumeGame();
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

