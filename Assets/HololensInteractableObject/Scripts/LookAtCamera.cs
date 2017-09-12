﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour {

    private Transform hololensCamera;

	// Use this for initialization
	void Start () {
        hololensCamera = Camera.main.transform;
	}
	
	// Update is called once per frame
	void Update () {        
        transform.LookAt(hololensCamera);
        transform.Rotate(0, 180, 0);
	}
}
