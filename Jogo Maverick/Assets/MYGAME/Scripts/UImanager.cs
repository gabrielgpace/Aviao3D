using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private Player _playerInstance;

    // IN-GAME
    [SerializeField] private Transform airplaneHeight;
    [SerializeField] private TMP_Text airplaneHeightTxt;
    [SerializeField] private GameObject airplaneHeightWarning;
    [SerializeField] private GameObject inGameUI;

    // PAUSE
    [SerializeField] private GameObject pauseMenu;

    // GAMEOVER
    [SerializeField] private GameObject gameOver;

    // OPTIONS
    [SerializeField] private GameObject pauseOptions;

    private bool isPaused;

    private void Start()
    {
        _playerInstance = FindObjectOfType<Player>();
        if (_playerInstance == null)
        {
            Debug.LogError("Player não encontrado na cena.");
        }

        pauseMenu.SetActive(false);
        gameOver.SetActive(false);
        pauseOptions.SetActive(false);
        inGameUI.SetActive(true);

        if (airplaneHeight == null || airplaneHeightTxt == null || airplaneHeightWarning == null)
        {
            Debug.LogWarning("Alguma referência de UI está faltando.");
        }
    }

    private void Update()
    {
        if (_playerInstance != null && _playerInstance.gameOver)
        {
            ActivateGameOver();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                ActivatePauseMenu();
            }
        }

        UpdateUIInfo();
    }

    private void UpdateUIInfo()
    {
        if (airplaneHeight != null && airplaneHeightTxt != null)
        {
            airplaneHeightTxt.text = airplaneHeight.localPosition.y.ToString("0") + "m";

            float heightThreshold = 100f; // Valor parametrizado
            airplaneHeightWarning?.SetActive(airplaneHeight.position.y > heightThreshold);
        }
    }

    public void ActivateGameOver()
    {
        if (gameOver != null)
        {
            gameOver.SetActive(true);
            inGameUI.SetActive(false);
            Time.timeScale = 0;
        }
    }

    public void ActivatePauseMenu()
    {
        isPaused = true;
        if (pauseMenu != null)
        {
            pauseMenu.SetActive(true);
            inGameUI.SetActive(false);
            Time.timeScale = 0;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void PlayAgain()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Level1");
    }

    public void Resume()
    {
        isPaused = false;
        if (pauseMenu != null)
        {
            pauseMenu.SetActive(false);
            inGameUI.SetActive(true);
            Time.timeScale = 1;
        }
    }
}
