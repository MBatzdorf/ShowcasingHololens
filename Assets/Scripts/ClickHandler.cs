using HoloToolkit.Unity;
using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickHandler : MonoBehaviour, IInputClickHandler {

	public GameObject contextMenu;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnInputClicked(InputClickedEventData eventData)
	{
		if (contextMenu.activeSelf) {
			contextMenu.SetActive (false);
		} else {
			contextMenu.SetActive (true);
		}
	}
}
