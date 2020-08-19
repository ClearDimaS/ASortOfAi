using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Facing 
{
    Inside,
    Outside
}

public class PlaceInCircle : MonoBehaviour
{
    [Tooltip("Is the object facing inside the circle or outside")]
    [SerializeField]
    Facing Facing;

    [SerializeField]
    int ObjectsTotal;

    [SerializeField]
    GameObject IntstantiatedObject;

    [SerializeField]
    int Radius;

    void Start()
    {
        float addDeg = getAddDeg();

        int elmentsTotal = ObjectsTotal;
        for (int i = 0; i < elmentsTotal; i++) 
        {
            GameObject obstacle = Instantiate(IntstantiatedObject, this.transform, false) as GameObject;

            float degAngle = 360.0f / elmentsTotal * i;

            Quaternion rotation = Quaternion.Euler(0, 0, degAngle + addDeg);

            Vector3 localPosition = new Vector3(Radius * Mathf.Cos(degAngle * Mathf.Deg2Rad), Radius * Mathf.Sin(degAngle * Mathf.Deg2Rad), 0);

            obstacle.transform.localPosition = localPosition;

            obstacle.transform.rotation = rotation;
        }
    }

    private float getAddDeg()
    {
        if (Facing == Facing.Inside)
            return 90.0f;
        else
            return -90.0f;
    }
}
