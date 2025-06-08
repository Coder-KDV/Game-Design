using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Text scoreText;
    public Text highScoreText;
    public GameObject gameOverPanel;
    public GameObject startGamePanel;

    private int score = 0;
    private int highScore = 0;

    public bool IsGameOver { get; private set; }
    public bool IsGameStarted { get; private set; }

    public AudioSource audioSource;
    public AudioClip audioClip;

    void Awake()
    {
        Instance = this;
        IsGameStarted = false;
        startGamePanel.SetActive(true);
        Time.timeScale = 0f;
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.gameObject.SetActive(false);
    }

    private void Start()
    {
        Application.targetFrameRate = 90;
    }

    void Update()
    {
        // Quit the game when Escape is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ExitGame();
        }

        if (!IsGameStarted && !IsGameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space) ||
               (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
            {
                StartGame();
            }
        }

        if (IsGameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space) ||
               (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
            {
                ResetGame();
            }
        }
    }

    private void ExitGame()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        IsGameStarted = true;
        startGamePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void AddScore()
    {
        if (IsGameOver) return;
        score++;
        scoreText.text = score.ToString();
        Debug.Log(score);
    }

    public void GameOver()
    {
        if (audioSource != null && audioClip != null)
        {
            audioSource.clip = audioClip;
            audioSource.Play();
        }

        IsGameOver = true;
        gameOverPanel.SetActive(true);

        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
        }

        highScoreText.text = "High Score: " + highScore.ToString();
        highScoreText.gameObject.SetActive(true);

        Time.timeScale = 0f;
    }

    public void ResetGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
