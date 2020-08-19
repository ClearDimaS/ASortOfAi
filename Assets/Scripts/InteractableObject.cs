using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    private void Start()
    {
        InteractablObjectModel interactablModel = new InteractablObjectModel(transform, false);

        InteractableObjectsStatesController.instance.AddFree(interactablModel);
    }
}
