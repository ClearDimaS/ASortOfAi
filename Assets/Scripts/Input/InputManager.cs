using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager
{
    public bool SpacePressed() 
    {
        return Input.GetKeyDown(KeyCode.Space);
    }
}
