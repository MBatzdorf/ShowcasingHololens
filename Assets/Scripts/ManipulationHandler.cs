using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ManipulationHandler : MonoBehaviour, IManipulationHandler {

    public bool IsActive { get; set; }
    private Vector3 previousPosition;

    private void Awake()
    {
        IsActive = false;
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
        if (IsActive)
        {
            previousPosition = eventData.CumulativeDelta;
        }
        return;
    }

    public void OnManipulationUpdated(ManipulationEventData eventData)
    {
        if (IsActive)
        {
            Vector3 movementVector = new Vector3(0, 0, 0);
            Vector3 currentPosition = eventData.CumulativeDelta;
            movementVector = currentPosition - previousPosition;
            previousPosition = currentPosition;
            transform.position += movementVector;
        }
        return;
        
    }


}
