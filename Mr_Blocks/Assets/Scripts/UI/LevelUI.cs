using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LevelUI : MonoBehaviour
{
    public GameObject levelPanel;
    public TextMeshProUGUI levelText;
    public int levelNumber;

    public GameObject gameOverPanel;
    public Button restartButton;
    public LevelManager levelManager;
    public TextMeshProUGUI gameOverText;

    public Button menuButton;

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

        UpdateLevelText();
    }

    private void UpdateLevelText()
    {
        levelText.text = "Level : " + levelNumber;
    }

    private void AddListeners()
    {
        menuButton.onClick.AddListener(MainMenuButton);
        restartButton.onClick.AddListener(RestartButton);
    }

    private void MainMenuButton()
    {
        if (soundManager != null)
        {
            soundManager.PlayButtonClickAudio();
            soundManager.DestroySoundManager();
        }
        levelManager.LoadMainMenu();
    }

    private void RestartButton()
    {
        if (soundManager != null)
        {
            soundManager.PlayButtonClickAudio();
        }
        levelManager.RestartLevel();
    }

    private void HideLevelPanel()
    {
        levelPanel.SetActive(false);
    }

    private void SetGameOverPanel(bool isActive)
    {
        gameOverPanel.SetActive(isActive);
    }

    public void ShowGameWinUI()
    {
        SetGameOverPanel(true);

        gameOverText.text = "Game Completed!!";
        gameOverText.color = Color.green;
        HideLevelPanel();
    }

    public void ShowGameLoseUI()
    {
        SetGameOverPanel(true);

        gameOverText.text = "Game Over!!";
        gameOverText.color = Color.red;
        HideLevelPanel();
    }
}
