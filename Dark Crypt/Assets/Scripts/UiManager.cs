using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiManager : MonoBehaviour
{
    public GameObject gameOver;
    public TextMeshProUGUI winLoseText;

    public bool zombieCanMove = true;

    public static UiManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else { Destroy(gameObject); }
    }

    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void ShowGameOver(bool isWin)
    {
        winLoseText.text = (isWin ? "YOU WON!" : "YOU LOST!");
        gameObject.SetActive(true);
    }

    public void PlayAgain()
    {
        zombieCanMove= false;
        SceneManager.LoadScene("TheCrypt");
    }

    public void StartPlaying()
    {
        SceneManager.LoadScene("TheCrypt");
    }

}
