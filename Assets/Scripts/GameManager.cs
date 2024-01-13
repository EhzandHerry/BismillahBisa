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
    }

    // Update is called once per frame
    void Update()
    {
        GameOver();
    }

    public void StartGame()
    {
        playerController.gameOver = false;
    }

    public void GameOver()
    {
        if (playerController.gameOver)
        {
            Time.timeScale = 0;
            PanelGameOver.SetActive(true);
        }
    }
    public void RestartGame()//untukk restart game
    {
        SceneManager.LoadScene(1);
        playerController.gameOver = false;
    }

}