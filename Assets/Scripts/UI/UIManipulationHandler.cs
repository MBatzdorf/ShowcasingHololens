using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UIManipulationHandler : MonoBehaviour, IManipulationHandler {

	public Transform canvas;
	private Vector3 previousPosition;

	private void Awake()
	{
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
		Debug.Log("UPDATING UI MANIPULATION");
			Vector3 movementVector = new Vector3(0, 0, 0);
			Vector3 currentPosition = eventData.CumulativeDelta;
			movementVector = currentPosition - previousPosition;
			previousPosition = currentPosition;
			canvas.position += movementVector;
	}
}
