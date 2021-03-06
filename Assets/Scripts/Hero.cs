﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Hero : MonoBehaviour
{
    [Tooltip("A number from 0.0 to 1.0, NOT PERCENTAGE!")]
    [SerializeField]
    float ChangePlaceProbability;

    [Tooltip("Number defining speed of moving players")]
    [SerializeField]
    float Speed;

    HeroModel heroModel;

    InteractablObjectModel target;

    IEnumerator coroutine;

    private float stopDistance;

    private void Awake()
    {
        heroModel = new HeroModel
        {
            Speed = Speed
        };

        Controlls.OnTrigger += MoveToTarget;

        stopDistance = GetComponent<RectTransform>().rect.width / 15.0f;
    }

    private void MoveToTarget()
    {
        TryChangeTarget();
    }

    private void TryChangeTarget()
    {
        if (target == null)
        {
            SetNewTarget();
        }
        else 
        {
            float randFloat = UnityEngine.Random.Range(0.0f, 1.0f);
            if (randFloat < ChangePlaceProbability)
            {
                if (target != null)
                {
                    InteractableObjectsStatesController.instance.RealeseObject(target);
                }
                SetNewTarget();
            }
        }
    }

    private void SetNewTarget()
    {
        target = InteractableObjectsStatesController.instance.GetRandomInteractableObject();

        if (coroutine == null)
        {
            coroutine = Move();
            StartCoroutine(coroutine);
        }
    }

    private IEnumerator Move()
    {
        Vector3 difVec = (target.transform.localPosition - transform.localPosition);

        transform.up = difVec.normalized;

        while ((difVec).magnitude > stopDistance)
        {
            yield return null;

            while (target.isBusy)
            {
                SetNewTarget();
            }

            difVec = (target.transform.localPosition - transform.localPosition);

            transform.up = difVec.normalized;

            transform.localPosition += transform.up * heroModel.Speed * Time.deltaTime;
        }

        OnEndMovement();
        
        StopCoroutine(coroutine);

        coroutine = null;
    }

    private void OnEndMovement()
    {
        InteractableObjectsStatesController.instance.BusyObject(target);

        transform.up = (new Vector3(0.0f, 0.0f, 0.0f) - transform.localPosition).normalized;
    }
}
