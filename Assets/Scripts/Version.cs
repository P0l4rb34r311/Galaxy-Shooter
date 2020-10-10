using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Version : MonoBehaviour
{
    [SerializeField]
    private Text _versionTxt;

    void Start()
    {
        _versionTxt.text = "Ver. " + Application.version;
    }

}
