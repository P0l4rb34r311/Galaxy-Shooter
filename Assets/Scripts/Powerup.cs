using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3f;

    [SerializeField] 
    private int _powerupID;
    [SerializeField]
    private GameObject _sound;

    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        
        if(transform.position.y < -5.8f)
        {
            Destroy(this.gameObject);
        }
                
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Player player = other.transform.GetComponent<Player>();
            Instantiate(_sound, transform.position, Quaternion.identity);
            if(player != null)
            {
                
                switch(_powerupID)
                {
                    case 0:
                        player.TripleShotActive();
                        break;
                    case 1:
                        player.SpeedBoostActive();
                        break;
                    case 2:
                        player.ShieldsActive();
                        break;
                    case 3:
                        player.AmmoCollected();
                        break;
                    case 4:
                        player.LivesCollected();
                        break;
                    case 5:
                        player.LaserCanon();
                        break;
                    default:
                        Debug.Log("default");
                        break;

                }
                
            }
            Destroy(this.gameObject);
        }
    }

}
