using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void QuitGame()
    {
        Debug.Log("game closed!");
        Application.Quit();
    }
    public void SelectGame(int level)
    {
        Debug.Log("level" + level.ToString());
        SceneManager.LoadScene("level" + level.ToString());
    }
}
