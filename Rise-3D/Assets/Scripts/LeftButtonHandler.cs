using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftButtonHandler : MonoBehaviour
{
    public static LeftButtonHandler Instance { get; set; }
    public bool leftButtonDown;

    private void Awake()
    {
        Instance = this;
    }

    public void OnPressLeft()
    {
        leftButtonDown = true;
    }

    public void OnReleaseLeft()
    {
        leftButtonDown = false;
    }
}
