using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private bool _isGameOver;
    [SerializeField]
    private GameObject _pauseMenu;
    private UIManager _uiManager;
    [SerializeField]
    private Animator _animator;
    public static float _pauseSounds;

    void Start()
    {
        Time.timeScale = 1;
        _pauseSounds = AudioListener.volume = 1;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && _isGameOver == true)
        {
            SceneManager.LoadScene(1); //Game start scene
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0); //Main Menu
        } 
        if (Input.GetKeyDown(KeyCode.P) && _isGameOver == false)
        {
            PauseMenu();
        }
    }
    public void ResumeGame()
    {
        _pauseMenu.SetActive(false);
        Time.timeScale = 1;
        _pauseSounds = AudioListener.volume = 1;
    }

    public void GameOver()
    {
        _isGameOver = true;
    }
    public void PauseMenu()
    {
        if (_pauseMenu.activeSelf == true)
        {
            _pauseMenu.SetActive(false);
            Time.timeScale = 1;
            _pauseSounds = AudioListener.volume = 1;
        }
        else
        {
            _pauseMenu.SetActive(true);
            _animator.SetBool("Pause", true);
            Time.timeScale = 0;
            _pauseSounds = AudioListener.volume = 0;

        }
    }
}
