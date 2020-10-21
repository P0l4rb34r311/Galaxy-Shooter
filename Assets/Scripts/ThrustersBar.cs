using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThrustersBar : MonoBehaviour
{
    [SerializeField]
    public Slider _thrusters;

    public void SetThrustersMax(float playerThrusters)
    {
        _thrusters.maxValue = playerThrusters;
        _thrusters.value = playerThrusters;
    }

    public void SetThrusters(float playerThrusters)
    {
        _thrusters.value = playerThrusters;
    }
}
