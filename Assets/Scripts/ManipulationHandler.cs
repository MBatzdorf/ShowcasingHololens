using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ManipulationHandler : MonoBehaviour, IManipulationHandler {

    private Vector3 previousPosition;


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
        Vector3 movementVector = new Vector3(0, 0, 0);
        Vector3 currentPosition = eventData.CumulativeDelta;
        movementVector = currentPosition - previousPosition;
        previousPosition = currentPosition;
        transform.position += movementVector;
    }

}
