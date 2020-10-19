using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using TMPro;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.Audio;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.5f; 
    private float _speedMultiplyer = 2f;
    [SerializeField]
    private float _fireRate = 0.5f;
    private float _canFire = -1f;
    [SerializeField]
    private float _lives = 3f;
    [SerializeField]
    private int _score = 0;
    [SerializeField]
    private float _shields = 3f;
    private bool _isTripleShotActive = false;
    private bool _isSpeedBoostActive = false;
    private bool _isShieldsActive = false;
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private GameObject _tripleShotPrefab;
    [SerializeField]
    private GameObject _shieldVisualizer;
    [SerializeField]
    private GameObject _rightWingDamage;
    [SerializeField]
    private GameObject _leftWingDamage;
    [SerializeField]
    private GameObject _thrusters;
    private SpawnManager _spawnManager;
    private UIManager _uIManager;
    [SerializeField]
    private AudioClip _laserSound;
    private AudioSource _audioSource;
    private SpriteRenderer _sprite;



    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();
        _uIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        _audioSource = GetComponent<AudioSource>();
        _sprite = _shieldVisualizer.GetComponent<SpriteRenderer>();

        if (_sprite == null)
        {
            Debug.LogError("ShieldViz is null");
        }
        if (_spawnManager == null)
        {
            Debug.LogError("Spawn Manager is NULL");
        }
        if (_uIManager == null)
        {
            Debug.LogError("UI Manager is NULL");
        }
        if (_audioSource == null)
        {
            Debug.LogError("AudioSource on the player is NULL");
        }
        else
        {
            _audioSource.clip = _laserSound;
        }
    }

    void Update()
    {
        CalculateMovement();
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire)
        {
            FiringMechanism();
        }
        Thrusters();
    }

    void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);
        transform.Translate(direction * _speed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -3.8f, 0), 0);

        if (transform.position.x >= 11.3f)
        {
            transform.position = new Vector3(-11.3f, transform.position.y, 0);
        }
        else if (transform.position.x <= -11.3f)
        {
            transform.position = new Vector3(11.3f, transform.position.y, 0);
        }
    }

    void FiringMechanism()
    {
        _canFire = Time.time + _fireRate;
        if (_isTripleShotActive == true)
        {
            Instantiate(_tripleShotPrefab, transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(_laserPrefab, transform.position + new Vector3(0, 1.05f,  0), Quaternion.identity);
        }
        _audioSource.Play();
    }

    public void Damage(float damage)
    {
        if (_isShieldsActive == true)
        {
            _shields -= damage;
            Shields();
            return;
        }

        _lives -= damage;
        int _livesInt = (int)_lives;
        if(_livesInt == 2)
        {
            _rightWingDamage.SetActive(true);
        }
        else if(_livesInt == 1)
        {
            _leftWingDamage.SetActive(true);
        }

        _uIManager.UpdateLives(_livesInt);

        if(_livesInt < 1)
        {
            _spawnManager.OnPlayerDeath();
            Destroy(this.gameObject);
        }
    }

    public void TripleShotActive()
    {
        _isTripleShotActive = true;
        StartCoroutine(TripleShotPowerDownRoutine());
    }


    IEnumerator TripleShotPowerDownRoutine()
    {
        while(_isTripleShotActive == true)
        {
            yield return new WaitForSeconds(4f);
            _isTripleShotActive = false;
        }
        
        
    }

    public void SpeedBoostActive()
    {
        _isSpeedBoostActive = true;
        _speed *= _speedMultiplyer;
        StartCoroutine(SpeedBoostPowerDown());
    }

    IEnumerator SpeedBoostPowerDown()
    {
        while(_isSpeedBoostActive == true)
        {
            yield return new WaitForSeconds(4f);
            _speed /= _speedMultiplyer;
            _isSpeedBoostActive = false;
        }
    }

    public void ShieldsActive()
    {
        _isShieldsActive = true;
        _shieldVisualizer.SetActive(true);
    }

    public void AddScore(int points)
    {
        _score += points;
        _uIManager.UpdateScore(_score);
    }
    private void Thrusters()
    {

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _thrusters.SetActive(true);
            _speed *= 1.5f;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            _thrusters.SetActive(false);
            _speed /= 1.5f;
        }

    }
    private void Shields()
    {
        if (_shields == 3)
        {
            _sprite.color = new Color(1, 1, 1, 1);
            Debug.Log("Full");
        }
        if (_shields == 2)
        {
            _sprite.color = new Color(1, 0.4442f, 0, 1);
            Debug.Log("Half");
        }
        if (_shields == 1)
        {
            _sprite.color = new Color(1, 0, 0, 1);
            Debug.Log("Low");
        }
        if (_shields < 1)
        {
            _isShieldsActive = false;
            _shieldVisualizer.SetActive(false);
        }

    }
}
