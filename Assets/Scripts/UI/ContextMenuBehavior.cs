using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContextMenuBehavior : MonoBehaviour {

	public GameObject associatedObject;
	private ObjectStateManager stateManager;
	private Canvas canvas;

	// Use this for initialization
	void Start () {
		stateManager = ObjectStateManager.Instance;
		canvas = GetComponent<Canvas> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (associatedObject == stateManager.SelectedObject) {
			canvas.enabled = true;
		} else {
			canvas.enabled = false;
		}
	}
}
