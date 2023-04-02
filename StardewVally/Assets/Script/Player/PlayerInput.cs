using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public string HorizontaolAxisName = "Horizontal";
    public string VerticalAxisName = "Vertical";
    public float InputX { get; private set; }
    public float InputY { get; private set; }

    private void Update()
    {
        InputX = Input.GetAxis(HorizontaolAxisName);
        InputY = Input.GetAxis(VerticalAxisName);
    }
}
