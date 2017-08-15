using HoloToolkit.Unity;
using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NavigationHandler : MonoBehaviour, INavigationHandler {

    public float RotationSensitivity = 10.0f;
        
    public void OnNavigationStarted(NavigationEventData eventData)
    {
        throw new NotImplementedException();
    }

    public void OnNavigationUpdated(NavigationEventData eventData)
    {
        float rotationFactorX = eventData.CumulativeDelta.y * RotationSensitivity;
        float rotationFactorY = eventData.CumulativeDelta.x * RotationSensitivity;
        float rotationFactorZ = eventData.CumulativeDelta.z * RotationSensitivity;
        this.transform.Rotate(new Vector3(-1 * rotationFactorX, -1 * rotationFactorY, -1 * rotationFactorZ));
    }

    public void OnNavigationCompleted(NavigationEventData eventData)
    {
        throw new NotImplementedException();
    }

    public void OnNavigationCanceled(NavigationEventData eventData)
    {
        throw new NotImplementedException();
    }
}
