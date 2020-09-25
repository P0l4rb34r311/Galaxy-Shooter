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


    void Start()
    {
        transform.position = new Vector3(0, 8, 0);
    }


    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        transform.position = new Vector3(0, transform.position.y, 0);
        //transform.Rotate(Vector3.forward * _rotateSpeed * Time.deltaTime);
 
        if (transform.position.y < -6f)
        {
            transform.position = new Vector3(0, 8, 0);
        }
        // Code added to start  asteroid off screen and loop through on a fixed axis til the player shoots it.
        // gives the appearance of the asteriod moving
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Laser")
        {
            Destroy(other.gameObject);
            Instantiate(_explosion, transform.position, Quaternion.identity);
            Destroy(GetComponent<Collider2D>());
            Destroy(this.gameObject, 0.25f);
        }
    }
}
