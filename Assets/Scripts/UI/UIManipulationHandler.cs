using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

public class UIManipulationHandler : MonoBehaviour, IPointerUpHandler, IPointerDownHandler, IManipulationHandler {

	public float movementSpeed = 0.1f;
	public GameObject currentObject;
	public Transform cameraTransform;

	private Vector3 previousPosition;

	void Start()
	{
		InputManager.Instance.AddGlobalListener(gameObject);
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
		Debug.Log ("Position update requested");
		previousPosition = eventData.CumulativeDelta;
	}

	public void OnManipulationUpdated(ManipulationEventData eventData)
	{
		Vector3 manipulationData = eventData.CumulativeDelta;
		Vector3 directionVector = manipulationData * movementSpeed;
		currentObject.transform.position += directionVector;
		Debug.Log ("Position updated");
	}


	public void OnPointerDown(PointerEventData eventData)
	{
		currentObject.transform.SetParent (cameraTransform);
		Debug.Log ("Mouse down");
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		Vector3 tempTransform = currentObject.transform.position;
		currentObject.transform.SetParent (null);
		currentObject.transform.position = tempTransform;
		Debug.Log ("Mouse Up");
	}
}