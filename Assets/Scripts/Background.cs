using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField]
    private float _rotateSpeed = 3.0f;
    void Update()
    {
        transform.Rotate(Vector3.back * _rotateSpeed * Time.deltaTime, Space.Self);
    }
}
