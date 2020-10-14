using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private bool _isGameOver;
    [SerializeField]
    private GameObject _pauseMenuPanel;
    private UIManager _uiManager;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && _isGameOver == true)
        {
            SceneManager.LoadScene(1); //Main Menu Scene
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        } 
        if(Input.GetKeyDown(KeyCode.P))
        {
            _pauseMenuPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void GameOver()
    {
        _isGameOver = true;
    }
}
