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
    private Animator _animator;

    void Start()
    {
        _animator = GameObject.Find("Pause_Menu_Panel").GetComponent<Animator>();
        if (_animator == null)
        {
            Debug.LogError("PauseAnimator is NULL");
        }
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
        if (Input.GetKeyDown(KeyCode.P))
        {
            _pauseMenu.SetActive(true);

            Time.timeScale = 0;
            _animator.SetBool("Pause", true);         
        }
    }
    public void ResumeGame()
    {
        _pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void GameOver()
    {
        _isGameOver = true;
    }
}
