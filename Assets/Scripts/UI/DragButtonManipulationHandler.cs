using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

public class DragButtonManipulationHandler : MonoBehaviour, IManipulationHandler {

	public float movementSpeed = 0.1f;
	public GameObject currentObject;
	public Transform cameraTransform;
	public Color highlightedColor;

	private Vector3 previousPosition;
	private ObjectStateManager stateManager;
	private Button dragButton;

	void Start()
	{
		InputManager.Instance.AddGlobalListener(gameObject);
		stateManager = ObjectStateManager.Instance;
		dragButton = GetComponent<Button> ();
	}

	void Update()
	{
		if(gameObject == stateManager.SelectedObject)
		{
			ColorBlock colors = dragButton.colors;
			colors.normalColor = highlightedColor;
			colors.highlightedColor = highlightedColor;
			colors.pressedColor = highlightedColor;
			dragButton.colors = colors;
		}
		else{
			ColorBlock colors = dragButton.colors;
			colors.normalColor = Color.white;
			colors.highlightedColor = Color.white;
			colors.pressedColor = Color.white;
			dragButton.colors = colors;
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
		previousPosition = eventData.CumulativeDelta;
	}

	public void OnManipulationUpdated(ManipulationEventData eventData)
	{
        if (gameObject == ObjectStateManager.Instance.SelectedObject)
        {
            Vector3 manipulationData = eventData.CumulativeDelta;
            Vector3 directionVector = manipulationData * movementSpeed;
            currentObject.transform.position += directionVector;
        }
        else
        {
            return;
        }
	}
}