using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Taken from http://answers.unity3d.com/questions/132592/lookat-in-opposite-direction.html

public class HololensCanvas : MonoBehaviour {

	private Transform camera;

	void Start()
	{
		camera = GameObject.FindGameObjectWithTag ("MainCamera").transform;

		if (camera != null) {
			GetComponent<Canvas> ().worldCamera = camera.gameObject.GetComponent<Camera>();
		}
	}

	// Update is called once per frame
	void Update () {
		LookAtMainCamera ();
	}

	void LookAtMainCamera()
	{
		if (camera != null) {
			transform.rotation = Quaternion.LookRotation(transform.position - camera.position);
		}
	}
}
