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

    private void Update()
    {
        if (inputControlls.SpacePressed())
        {
            OnTrigger?.Invoke();
        }
    }
}
