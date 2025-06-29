using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private int currentSceneIndex;
    public LevelUI levelUI;
    private const int mainMenuIndex = 0;

    private void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(mainMenuIndex);
    }

    public void OnLevelComplete()
    {
        Debug.Log("Level Complete!");
        LoadNextLevel();
    }

    private void LoadNextLevel()
    {
        int nextSceneIndex = currentSceneIndex + 1;
        int totalNumberOfScenes = SceneManager.sceneCountInBuildSettings;

        if(nextSceneIndex < totalNumberOfScenes)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            levelUI.ShowGameWinUI();
        }
    }

    public void OnPlayerDeath()
    {
        levelUI.ShowGameLoseUI();
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(currentSceneIndex);
    }
}
