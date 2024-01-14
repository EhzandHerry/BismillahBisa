using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public PlayerController playerController;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highscoreText;
    // Key untuk menyimpan highscore dalam PlayerPrefs
    private string highscoreKey = "Highscore";

    private float gameTime;

    public Button restartButton;

    //public static bool isGameOver;//ngasih tau game over belumnya (gamenya masih jalan gasih ?)
    public GameObject PanelGameOver;

    private void Awake()
    {
        // Ensure PlayerController has been assigned
        if (playerController == null)
        {
            Debug.LogError("GameManager: Please assign PlayerController script in the Inspector!");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        StartGame();
        // Load highscore saat memulai permainan
        LoadHighscore();
    }

    // Update is called once per frame
    void Update()
    {
        GameOver();
    }

    public void StartGame()
    {
        gameTime = 0f;
        playerController.gameOver = false;
        StartCoroutine(UpdateScore());
    }

    public void GameOver()
    {
        if (playerController.gameOver)
        {
            // Cek apakah waktu saat ini lebih tinggi dari highscore
            if (gameTime > GetHighscore())
            {
                // Jika iya, update highscore dan simpan
                SetHighscore(gameTime);
                SaveHighscore();
            }

            Time.timeScale = 0;
            PanelGameOver.SetActive(true);

            // Tampilkan highscore pada UI
            highscoreText.text = "Highscore: " + FormatTime(GetHighscore());
        }
        if (!playerController.gameOver)
        {
            gameTime += Time.deltaTime;
        }
    }
    public void RestartGame()//untukk restart game
    {
        // Reset game state variables
        playerController.gameOver = false;
        Time.timeScale = 1; // Resume game time
        PanelGameOver.SetActive(false); // Hide game over panel

        // Optionally, reset other game elements here (e.g., player position, scores, etc.)

        // Reinitialize the scene (optional, if needed for a full reset)
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        StartGame();
    }

    IEnumerator UpdateScore()
    {
        while (true)
        {
            if (!playerController.gameOver)
            {
                // Format waktu menjadi menit:detik
                string formattedTime = FormatTime(gameTime);

                // Tampilkan skor pada UI
                scoreText.text = "Time: " + formattedTime;

                yield return null;
            }
            else
            {
                yield break;
            }
        }
    }
    string FormatTime(float timeInSeconds)
    {
        int minutes = Mathf.FloorToInt(timeInSeconds / 60);
        int seconds = Mathf.FloorToInt(timeInSeconds % 60);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    // Fungsi untuk menyimpan highscore ke PlayerPrefs
    void SaveHighscore()
    {
        PlayerPrefs.SetFloat(highscoreKey, GetHighscore());
        PlayerPrefs.Save();
    }

    // Fungsi untuk mendapatkan highscore dari PlayerPrefs
    float GetHighscore()
    {
        return PlayerPrefs.GetFloat(highscoreKey, 0f);
    }

    // Fungsi untuk mengatur highscore baru
    void SetHighscore(float newHighscore)
    {
        PlayerPrefs.SetFloat(highscoreKey, newHighscore);
    }

    // Fungsi untuk memuat highscore dari PlayerPrefs
    void LoadHighscore()
    {
        // Tampilkan highscore pada UI saat memulai permainan
        highscoreText.text = "Highscore: " + FormatTime(GetHighscore());
    }

}