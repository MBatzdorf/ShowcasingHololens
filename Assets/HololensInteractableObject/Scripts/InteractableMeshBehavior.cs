using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableMeshBehavior : MonoBehaviour {

	public GameObject ContextMenu;

	// Use this for initialization
	void Start () {
		if (ContextMenu == null)
			this.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnBecameVisible()
	{
		ContextMenu.SetActive (true);
	}

	void OnBecameInvisible()
	{
		ContextMenu.SetActive (false);
	}
}
