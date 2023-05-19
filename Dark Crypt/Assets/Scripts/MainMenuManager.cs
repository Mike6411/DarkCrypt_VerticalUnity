using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{

    public static MainMenuManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else { Destroy(gameObject); }
    }

    public void StartPlaying()
    {
        SceneManager.LoadScene("TheCrypt");
    }

    public void Options()
    {
        SceneManager.LoadScene("Options");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void Tuorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void QuitGame () 
    {
        Application.Quit();
    }
}
