using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private float _speed = 8.0f;
    //private bool _isEnemyLaser = false;

    void Update()
    {       
        //if(_isEnemyLaser == false)
        //{
            MoveUp();
        //}
        //else
        //{
            //MoveDown();
            //Debug.Log("Enemy laser detected");
        //}
    }

    void MoveUp()
    {
        transform.Translate(Vector3.up * _speed * Time.deltaTime);


        if (transform.position.y > 7f)
        {
            if (transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }
            Destroy(this.gameObject);
        }
        Debug.Log("Player laser called");
    }

    //void MoveDown()
    //{
        //transform.Translate(Vector3.down * _speed * Time.deltaTime);


        //if (transform.position.y < -7f)
        //{
            //if (transform.parent != null)
            //{
                //Destroy(transform.parent.gameObject);
            //}
            //Destroy(this.gameObject);
        //}
    //}

    //public void AssignEnemyLaser()
    //{
        //_isEnemyLaser = true;
    //}
   
}
