using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TerrainUtils;

public class MenuUIHandler : MonoBehaviour
{
    public GameManager gameManager;
    public PlayerController playerController;

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    //public void StartMain()
   // {
       // SceneManager.LoadScene(1);
   // }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BtnStart()
    {
        Debug.Log("Tombol Mulai diklik!");
        MainManager.Instance.RestartGame();
        SceneManager.LoadScene(1);
        //untuk memanggil scene lain
        //dipanggil di start button dibagian method piih, menuUIHandler trus ke method StartMain
    }
    public void BtnQuit()
    {
        EditorApplication.ExitPlaymode();
    }
    public void BtnHome()
    {
        SceneManager.LoadScene(0);
    }

    public void BtnRst()
    {
        GameManager gameManager = FindObjectOfType<GameManager>();
        if (gameManager != null)
        {
            //MainManager.Instance.RestartGame();
            gameManager.RestartGame();
        }

    }

    public void SaveName()
    {

    }

}
