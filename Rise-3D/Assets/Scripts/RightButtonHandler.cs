using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightButtonHandler : MonoBehaviour
{
    public static RightButtonHandler Instance { get; set; }
    public bool rightButtonDown;

    private void Awake()
    {
        Instance = this;
    }

    public void OnPressRight()
    {
        rightButtonDown = true;
    }

    public void OnReleaseRight()
    {
        rightButtonDown = false;
    }
}
