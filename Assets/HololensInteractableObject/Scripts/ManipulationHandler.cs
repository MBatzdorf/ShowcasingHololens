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

	private bool mHasGaze = false;
	//private Vector3 currentPosition;
	private Vector3 latestObjectPosition;
	private bool isDragging = false;

	private void Start()
	{
		IsActive = false;
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
			//Debug.Log("StartVec: " + startVector + " CurrVec: " + currentVector + " StartOrigin: " + startOrigin);
			base.ManipulationUpdate(startVector, currentVector, startOrigin, startRay, gestureState);

			//Vector3 mDirection = DirectionVector.normalized;
			/*if (isDragging)
            {
            } else
            {
            }*/
			Vector3 mCurrPos = DirectionVector.normalized;
			if(mCurrPos == Vector3.zero && latestObjectPosition != null)
			{
				mCurrPos = latestObjectPosition;
				Debug.LogError("Latest CURRPOS: " + mCurrPos);
			}
			Debug.Log("Direction vec: " + mCurrPos);
			Object.transform.localPosition = mCurrPos * FeebackVisualDistance;
			latestObjectPosition = Object.transform.localPosition;
			//Object.transform.localPosition = CurrentGesturePosition * FeebackVisualDistance;
			Debug.Log("Latest Object position: " + latestObjectPosition);
			//base.StartGesturePosition = Object.transform.localPosition;
		}

	}

	public void OnSelect()
	{

		if (latestObjectPosition != null)
		{
			Debug.LogError("ON SELECT");
			//currentPosition = latestObjectPosition;
			StartGesturePosition = latestObjectPosition;
			UpdateGesture();
			Debug.LogError("StartGesturePos " + latestObjectPosition);
		}
	}


}