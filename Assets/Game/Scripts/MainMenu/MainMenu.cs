using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void LoadSinglePlayerGame()
    {
        Debug.Log("Load Single Player");
        SceneManager.LoadScene("Single_Mode");
    }

    public void LoadCoOpModeGame()
    {
        Debug.Log("Load Co-Op Mode");
        SceneManager.LoadScene("Co-op_Mode");
    }
}
