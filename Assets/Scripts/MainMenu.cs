using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenuUI;
    public GameObject startGameUI;
    public GameObject exitGameUI;
    public GameObject newGameUI;

    void Start()
    {
        mainMenuUI.SetActive(true);
        startGameUI.SetActive(false);
        exitGameUI.SetActive(false);
        newGameUI.SetActive(false);
    }

    public void StartGamePressed()
    {
        mainMenuUI.SetActive(false);
        startGameUI.SetActive(true);
    }

    public void QuitGamePressed()
    {
        mainMenuUI.SetActive(false);
        exitGameUI.SetActive(true);
    }
    public void ContinuePressed()
    {
        SceneManager.LoadScene("Level");
    }
    public void NewGamePressed()
    {
        startGameUI.SetActive(false);
        newGameUI.SetActive(true);
    }
    public void QuitGameYesPressed()
    {
        Application.Quit();
    }
    public void QuitGameNoPressed()
    {
        exitGameUI.SetActive(false);
        mainMenuUI.SetActive(true);
    }
    public void NewGameYesPressed()
    {
        SceneManager.LoadScene("Level");
    }

    public void NewGameNoPressed()
    {
        newGameUI.SetActive(false);
        startGameUI.SetActive(true);
    }
}
