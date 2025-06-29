using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    public Button playButton;
    public Button quitButton;

    private const int firstLevel = 1;

    private void Awake()
    {
        AddListeners();
    }

    private void AddListeners()
    {
        playButton.onClick.AddListener(Play);
        quitButton.onClick.AddListener(Quit);
    }

    public void Play()
    {
        SceneManager.LoadScene(firstLevel);
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Game quit");
    }
}
