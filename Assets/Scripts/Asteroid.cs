using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField]
    private float _rotateSpeed = 3.0f;
    [SerializeField]
    private GameObject _explosion;

    void Start()
    {
        
    }


    void Update()
    {
        transform.Rotate(Vector3.forward * _rotateSpeed * Time.deltaTime);  
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Laser")
        {
            Destroy(other.gameObject);
            Instantiate(_explosion, transform.position, Quaternion.identity);
            Destroy(GetComponent<Collider2D>());
            Destroy(this.gameObject, 0.5f);
        }
    }
}
