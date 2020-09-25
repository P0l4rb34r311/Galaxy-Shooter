using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField]
    private float _rotateSpeed = 3.0f;
    private Animator _animator;

    void Start()
    {
        _animator = gameObject.GetComponent<Animator>();   
        if(_animator == null)
        {
            Debug.LogError("Animator is NULL");
        }
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
            _animator.SetTrigger("Explosion");
            Destroy(GetComponent<Collider2D>());
            Destroy(this.gameObject, 3.0f);
        }
    }
}
