using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

public class DragButtonManipulationHandler : MonoBehaviour, IPointerUpHandler, IPointerDownHandler, IManipulationHandler {

	public float movementSpeed = 0.1f;
	public GameObject currentObject;
	public Transform cameraTransform;
	public Image dragImage;
	public Sprite dragImageActive;
	public Sprite dragImageInactive;

	private Vector3 previousPosition;
	private ObjectStateManager stateManager;

	void Start()
	{
		InputManager.Instance.AddGlobalListener(gameObject);
		stateManager = ObjectStateManager.Instance;
	}

	void Update()
	{
		if(gameObject == stateManager.SelectedObject)
		{
			dragImage.sprite = dragImageActive;
		}
		else{
			dragImage.sprite = dragImageInactive;
		}
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
        if (gameObject == ObjectStateManager.Instance.SelectedObject)
        {
            Vector3 manipulationData = eventData.CumulativeDelta;
            Vector3 directionVector = manipulationData * movementSpeed;
            currentObject.transform.position += directionVector;
            Debug.Log("Position updated");
        }
        else
        {
            return;
        }
	}


	public void OnPointerDown(PointerEventData eventData)
	{
		return;
		currentObject.transform.SetParent (cameraTransform);
		Debug.Log ("Mouse down");
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		return;
		Vector3 tempTransform = currentObject.transform.position;
		currentObject.transform.SetParent (null);
		currentObject.transform.position = tempTransform;
		Debug.Log ("Mouse Up");
	}
}