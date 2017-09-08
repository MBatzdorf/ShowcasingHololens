using HoloToolkit.Unity;
using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NavigationHandler : MonoBehaviour, INavigationHandler {

    public bool IsActive { get; set; }
    public float RotationSensitivity = 3.0f;

    private void Start()
    {
        IsActive = true;
    }
    public void OnNavigationStarted(NavigationEventData eventData)
    {
        return;
    }

    public void OnNavigationUpdated(NavigationEventData eventData)
    {
        if (IsActive)
        {
            float rotationFactorX = eventData.CumulativeDelta.y * RotationSensitivity;
            float rotationFactorY = eventData.CumulativeDelta.x * RotationSensitivity;
            this.transform.Rotate(new Vector3(rotationFactorX, -1 * rotationFactorY, 0));
        }
        return;
        
    }

    public void OnNavigationCompleted(NavigationEventData eventData)
    {
        return;
    }

    public void OnNavigationCanceled(NavigationEventData eventData)
    {
        return;
    }
}
