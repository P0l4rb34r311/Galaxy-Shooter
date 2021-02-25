using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private Player _player;
    [SerializeField]
    private Text _scoreText;
    [SerializeField]
    private Text _bestScoreText;
    [SerializeField]
    private Text _gameOverText;
    [SerializeField]
    private Text _restartText;
    [SerializeField]
    private Text _ammoText;
    [SerializeField]
    private Image _livesImg;
    [SerializeField]
    private Sprite[] _liveSprites;
    private GameManager _gameManager;
    [SerializeField]
    private GameObject _ammoSlider;
    [SerializeField]
    private GameObject _thrusterSlider;
    [SerializeField]
    private GameObject _noAmmoPulse;
    private GameObject _pauseMenuPanel;
    private int _score;
    [SerializeField]
    private int _bestScore;
    private int _ammoCount;
    [SerializeField]
    private bool _resetBest = false; //reset best score

    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
        _scoreText.text = "Score: " + 0;
        _bestScore = PlayerPrefs.GetInt("HighScore", 0);
        _bestScoreText.text = "Best: " + _bestScore;
        _ammoText.text = 15 + "/15";
        _gameOverText.gameObject.SetActive(false);
        _restartText.gameObject.SetActive(false);
        _noAmmoPulse.gameObject.SetActive(false);
        _gameManager = GameObject.Find("Game_Manager").GetComponent<GameManager>();


        if (_gameManager == null)
        {
            Debug.LogError("GameManager is NULL");
        }
    }


    public void UpdateScore(int playerScore)
    {
        _scoreText.text = "Score: " + playerScore.ToString();
        _score = playerScore;

    }
    public void CheckForBestScore()
    {
        if (_score > _bestScore)
        {
            _bestScore = _score;
            PlayerPrefs.SetInt("HighScore", _bestScore);
            _bestScoreText.text = "Best: " + _bestScore;
        }
    }
    public void ResetBest() //Debug for dev
    {
        if (_resetBest == true)
        {
            _bestScore = 0;
        }
    }

    public void UpdateLives(int currentLives)
    {
        _livesImg.sprite = _liveSprites[currentLives];
        if (currentLives == 0)
        {
            GameOverSequence();
        }
    }

    void GameOverSequence()
    {
        CheckForBestScore();
        _gameManager.GameOver();
        _gameOverText.gameObject.SetActive(true);
        _restartText.gameObject.SetActive(true);
        StartCoroutine(GameOverFlickerRoutine());
    }

    IEnumerator GameOverFlickerRoutine()
    {
        while (true)
        {
            _gameOverText.text = "GAME OVER";
            yield return new WaitForSeconds(0.15f);
            _gameOverText.text = "";
            yield return new WaitForSeconds(0.15f);
        }

    }
    public void NoAmmoPulse(bool active)
    {
        if (active == true)
        {
            _noAmmoPulse.SetActive(true);
        }
        else
        {
            _noAmmoPulse.SetActive(false);
        }
    }
    public void AmmoCount(int playerAmmo)
    {
        _ammoText.text = playerAmmo.ToString() + "/15";
        _ammoCount = playerAmmo;
    }

    public void ResumeGameButton()
    {
        _gameManager.ResumeGame();
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene(0);
    }
    public void QuitButton()
    {
        Application.Quit();
    }
}
