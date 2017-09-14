using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// inspired by http://dotnetbyexample.blogspot.de/2017/01/manipulating-holograms-move-scale.html

public class MovementHandler : MonoBehaviour, IManipulationHandler {

    public float movementSpeed = 0.1f;
    public GameObject currentObject;
    public bool IsActive { get; set; }

    private Vector3 previousPosition;

    private void Awake()
    {
        IsActive = false;
    }

    void Start()
    {
        InputManager.Instance.AddGlobalListener(currentObject);
    }

    public void OnManipulationCanceled(ManipulationEventData eventData)
    {
        return;
    }

    public void OnManipulationCompleted(ManipulationEventData eventData)
    {
        return;
    }

    public void OnManipulationStarted(ManipulationEventData eventData)
    {
        previousPosition = eventData.CumulativeDelta;
    }

    public void OnManipulationUpdated(ManipulationEventData eventData)
    {
        if (IsActive)
        {
            Vector3 manipulationData = eventData.CumulativeDelta;
            Vector3 directionVector = manipulationData * movementSpeed;
            currentObject.transform.position += directionVector;
        }
    }
}
