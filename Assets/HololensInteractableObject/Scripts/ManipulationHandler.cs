using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using HoloToolkit.Examples.InteractiveElements;

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.
// based on GestureControlTest script


public class ManipulationHandler : GestureInteractiveControl {

    public bool IsActive { get; set; }



    public GameObject Object;
    public Interactive InteractiveElement;
    public float FeebackVisualDistance = 0.95f;


    private void Start()
    {
        Debug.Log("ManipulationHandler start!");
        IsActive = false;
        Debug.Log("ManipuliationHandler " + IsActive);
    }

    /// <summary>
    /// provide visual feedback based on state and update element position
    /// </summary>
    /// <param name="startVector"></param>
    /// <param name="currentVector"></param>
    /// <param name="startOrigin"></param>
    /// <param name="startRay"></param>
    /// <param name="gestureState"></param>
    public override void ManipulationUpdate(Vector3 startVector, Vector3 currentVector, Vector3 startOrigin, Vector3 startRay, GestureInteractive.GestureManipulationState gestureState)
    {
        if (IsActive)
        {
            base.ManipulationUpdate(startVector, currentVector, startOrigin, startRay, gestureState);

            Vector3 mDirection = DirectionVector.normalized;

            Object.transform.localPosition = mDirection * FeebackVisualDistance * CurrentPercentage;
            Debug.Log("Object position: " + Object.transform.localPosition);
            //base.StartGesturePosition = Object.transform.localPosition;
        }
        
    }
}
