using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controlls : MonoBehaviour
{
    InputManager inputControlls;

    private void Awake()
    {
        inputControlls = new InputManager();
    }

    public static Action OnTrigger;
    float lastTimePressed;
    float doubleClickDefTime = 0.5f;

    private void FixedUpdate()
    {
        if (inputControlls.SpacePressed())
        {
            if (NotDoubleClick()) 
            {
                lastTimePressed = Time.time;
                OnTrigger?.Invoke();
            }
        }
    }

    private bool NotDoubleClick()
    {
        return Time.time - lastTimePressed > doubleClickDefTime;
    }
}
