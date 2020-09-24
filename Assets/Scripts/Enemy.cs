using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4f;
    private Player _player;
    private Animator _animator;

    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
        _animator = gameObject.GetComponent<Animator>();

        if(_player == null)
        {
            Debug.LogError("Player is NULL");
        }
        if(_animator == null)
        {
            Debug.LogError("Animator is NULL");
        }
    }


    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if (transform.position.y < -5.5f)
        {
            float _randomX = Random.Range(-9.5f, 9.5f);
            transform.position = new Vector3(_randomX, 8, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player player = other.transform.GetComponent<Player>();
            
            if (player != null)
            {
                player.Damage();
            }
            _speed = 0;
            _animator.SetTrigger("OnEnemyDeath");

            Destroy(GetComponent<Collider2D>());
            Destroy(this.gameObject, 2.9f);
        }
        if (other.tag == "Laser")
        {
            Destroy(other.gameObject);
            if(_player != null)
            {
                _player.AddScore(10);
            }
            _speed = 0;
            _animator.SetTrigger("OnEnemyDeath");

            Destroy(GetComponent<Collider2D>());
            Destroy(this.gameObject, 2.9f);
        }
    }
}
