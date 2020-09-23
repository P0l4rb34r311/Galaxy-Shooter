using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _scoreText;
    void Start()
    {
        Player player = GameObject.Find("Player").GetComponent<Player>();
        _scoreText.text = "Score : " + 50;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
