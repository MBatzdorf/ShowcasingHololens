using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using HoloToolkit.Examples.InteractiveElements;

public class UIManipulationHandler : MonoBehaviour, IInputClickHandler {

	public Transform canvas;

	private void Awake()
	{
	}

	public void OnInputClicked(InputClickedEventData eventData)
	{
		GameObject camera = GameObject.FindGameObjectWithTag ("MainCamera");
		if(canvas.parent == camera.transform)
		{
			Vector3 tempPos = canvas.transform.position;
			canvas.SetParent (null);
			canvas.transform.position = tempPos;
		}
		else
		{
			canvas.SetParent (camera.transform);
		}
	}
}
