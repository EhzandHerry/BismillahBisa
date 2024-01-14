using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.IO;
using System;

public class MainManager : MonoBehaviour
{
    public AudioSource asBackSound;

    public Text tBackSound;

    //singleton
    public static MainManager Instance { get; set; }

    public GameManager gameManager;
    public PlayerController playerController;

    public TMP_InputField inputField;
    public TextMeshProUGUI display_nama;

    public string player_name;

    private void Awake()
    {

        asBackSound = GetComponent<AudioSource>();

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetNama()
    {
        player_name = inputField.text;
        SceneManager.LoadSceneAsync(1);
    }

    public void btnMute()
    {
        if (asBackSound.mute == false)
        {
            asBackSound.mute = true;
            tBackSound.text = "Music : off";
        }
        else
        {
            asBackSound.mute = false;
            tBackSound.text = "Music : on";
        }
    }

    public void Savedata()
    {
        PlayerPrefs .SetString("Input", inputField.text);
    }

    public void LoadData()
    {
        inputField.text = PlayerPrefs.GetString("Input");
    }

    public void RestartGame()
    {
        // Reset game state variables
        playerController.gameOver = false;
        Time.timeScale = 1; // Resume game time

        // Optionally, reset other game elements here (e.g., player position, scores, etc.)

        // Reinitialize the scene if needed
        if (gameManager != null)
        {
            gameManager.RestartGame();
        }
        else
        {
            Debug.LogWarning("GameManager not found. Scene may not be fully reset.");
        }
        Debug.Log("Game telah di-restart!");
    }
}
