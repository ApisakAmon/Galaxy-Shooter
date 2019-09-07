using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool isCoopMode = false;
    public bool GameOver = true;
    [SerializeField]
    private GameObject Player;
    [SerializeField]
    private GameObject CoopPlayer;
    [SerializeField]
    private GameObject PauseMenuPanel;
    private UIManager UIManager;
    private SpawnManager SpawnManager;
    private Animator PauseAnimator;

    private void Start()
    {
        UIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        SpawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        PauseAnimator = GameObject.Find("PauseMenuPanel").GetComponent<Animator>();
        PauseAnimator.updateMode = AnimatorUpdateMode.UnscaledTime;
    }

    void Update()
    {
        if (GameOver == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (isCoopMode == false)
                {
                    Instantiate(Player, Vector3.zero, Quaternion.identity);
                }
                else
                {
                    Instantiate(CoopPlayer, Vector3.zero, Quaternion.identity);
                }
                GameOver = false;

                UIManager.HintTitleScreen();
                SpawnManager.StartSpawnRoutine();
            }
            else if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene("MainMenu");
            }
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            PauseMenuPanel.SetActive(true);
            PauseAnimator.SetBool("isPaused", true);
            Time.timeScale = 0;
        }
    }

    public void ResumeGame()
    {
        PauseMenuPanel.SetActive(false);
        Time.timeScale = 1;
    }
}
