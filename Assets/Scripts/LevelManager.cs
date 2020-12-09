using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public int monsterLeft=0;
    public int levelState=0;

    public GameObject window;
    public GameObject winWord;
    public GameObject loseWord;

    private GameObject portal;
    private bool windowIsOpen=false;

    private void Start()
    {
        portal = GameObject.Find("Portal");
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && levelState==0)
        {
            if(windowIsOpen)
            {
                closeWindow();
                windowIsOpen=false;
            }
            else
            {
                showWindow(-1);
                windowIsOpen=true;
            }
        }
    }

    public void EnemyDie()
    {
        monsterLeft--;
        if(monsterLeft<=0)
        {
            portal.GetComponent<Portal>().isActive=true;
        }
    }
    
    public void Die()
    {
        if(levelState==0)
        {   
            levelState=1;
            showWindow(levelState);
            Debug.Log("lose!");
        } 
    }
    public void Win()
    {
        if(levelState==0)
        {
            levelState=2;
            showWindow(levelState);
            Debug.Log("win!");
        }   
    }

    private void showWindow(int levelState)
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        window.SetActive(true);
        if(levelState==1)
        {
            loseWord.SetActive(true);
            winWord.SetActive(false);
        }
        else if(levelState==2)
        {
            loseWord.SetActive(false); 
            winWord.SetActive(true);
        }
        else
        {
            loseWord.SetActive(false); 
            winWord.SetActive(false);
        }
    }
    private void closeWindow()
    {
        Cursor.lockState = CursorLockMode.Locked;
        window.SetActive(false);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Exit()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
