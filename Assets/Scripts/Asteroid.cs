using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{    
    [SerializeField]
    private float _speed = 0.25f;
    [SerializeField]
    private float _rotateSpeed = 3.0f;
    [SerializeField]
    private GameObject _explosion;
    private SpawnManager _spawnManager;

    void Start()
    {
        transform.position = new Vector3(0, 5, 0);
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();
        if(_spawnManager == null)
        {
            Debug.LogError("SpawnManager is NULL");
        }
    }


    void Update()
    { 
        transform.Rotate(Vector3.forward * _rotateSpeed * Time.deltaTime, Space.Self);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, 0, 0), transform.position.y, 0);
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        // Code added to loop asteroid through on a fixed y axis til the player shoots it.
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Laser")
        {
            Destroy(other.gameObject);
            Instantiate(_explosion, transform.position, Quaternion.identity);
            Destroy(GetComponent<Collider2D>()); 
            Destroy(this.gameObject, 0.25f);
            _spawnManager.StartSpawning();
        }
    }
    
}
