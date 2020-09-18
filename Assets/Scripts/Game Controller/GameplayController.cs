using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameplayController : MonoBehaviour {

    [SerializeField] private GameObject pausePanel;
    [SerializeField] private Button restartGameButton;
    [SerializeField] private Text scoreText, panelText;

    private int score;

    void Start() {
        scoreText.text = score + "M";
        StartCoroutine(CountScore());
    }

    IEnumerator CountScore() {
        yield return new WaitForSeconds(0.6f);
        score += 1;
        scoreText.text = score + "M";
        StartCoroutine(CountScore());
    }

    private void OnEnable() {
        PlayerDeathHandler.endGame += OnPlayerDeath;
    }

    private void OnDisable() {
        PlayerDeathHandler.endGame -= OnPlayerDeath;
    }

    private void OnPlayerDeath() {
        if (!PlayerPrefs.HasKey("Score")) {
            PlayerPrefs.SetInt("Score", 0);
        } else {
            int highScore = PlayerPrefs.GetInt("Score");
            if (highScore < score) {
                PlayerPrefs.SetInt("Score", score);
            }
        }

        panelText.text = "Game Over!";
        pausePanel.SetActive(true);
        restartGameButton.onClick.RemoveAllListeners();
        restartGameButton.onClick.AddListener(
            () => RestartGame()
        );

        Time.timeScale = 0f;
    }

    public void PauseTheGame() {
        Time.timeScale = 0f;
        panelText.text = "Pause";
        pausePanel.SetActive(true);
        restartGameButton.onClick.RemoveAllListeners();
        restartGameButton.onClick.AddListener(
            () => RestartGame()
        );
    }

    public void GoToMenu() {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void ResumeGame() {
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
    }

    public void RestartGame() {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Gameplay");
    }
}
