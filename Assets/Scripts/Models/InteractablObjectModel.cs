using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractablObjectModel
{
    public InteractablObjectModel(Transform _transform, bool _isBusy) 
    {
        transform = _transform;

        isBusy = _isBusy;
    }
    public void SetBusy(bool _isBusy) 
    {
        isBusy = _isBusy;
    }

    public Transform transform;

    public bool isBusy;
}
