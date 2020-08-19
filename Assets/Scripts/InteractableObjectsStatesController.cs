using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObjectsStatesController : MonoBehaviour
{
    #region Singleton
    public static InteractableObjectsStatesController instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    #endregion

    public List<InteractablObjectModel> InteractableObjectsFree;

    private List<InteractablObjectModel> InteractableObjectsBusy;

    private void Start()
    {
        InteractableObjectsFree = new List<InteractablObjectModel>();

        InteractableObjectsBusy = new List<InteractablObjectModel>();
    }

    public void AddFree(InteractablObjectModel interactableObject)
    {
        InteractableObjectsFree.Add(interactableObject);
    }

    public InteractablObjectModel GetRandomInteractableObject() 
    {
        InteractablObjectModel retVal = InteractableObjectsFree[Random.Range(0, InteractableObjectsFree.Count)];

        return retVal;
    }

    public void BusyObject(InteractablObjectModel interactableObject) 
    {
        interactableObject.isBusy = true;

        InteractableObjectsFree.Remove(interactableObject);

        InteractableObjectsBusy.Add(interactableObject);
    }

    public void RealeseObject(InteractablObjectModel interactableObject) 
    {
        interactableObject.isBusy = false;

        InteractableObjectsBusy.Remove(interactableObject);

        InteractableObjectsFree.Add(interactableObject);
    }
}
