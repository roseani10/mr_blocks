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

    private SoundManager soundManager;

    private void Awake()
    {
        AddListeners();
    }

    private void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();

        if (soundManager == null)
        {
            Debug.LogError("SoundManager not found in the scene.");
        }
    }

    private void AddListeners()
    {
        playButton.onClick.AddListener(Play);
        quitButton.onClick.AddListener(Quit);
    }

    public void Play()
    {
        if (soundManager != null)
        {
            soundManager.PlayButtonClickAudio();
        }
        SceneManager.LoadScene(firstLevel);
    }

    public void Quit()
    {
        if (soundManager != null)
        {
            soundManager.PlayButtonClickAudio();
        }
        Application.Quit();
        Debug.Log("Game quit");
    }
}
