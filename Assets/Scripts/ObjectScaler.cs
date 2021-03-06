﻿using HoloToolkit.Examples.InteractiveElements;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ObjectScaler : MonoBehaviour {

    public SliderGestureControl slider;

    private const int SliderOffset = 1;
    private Transform objectScale;

    // Use this for initialization
	void Start () {
        objectScale = GetComponent<Transform>();
	}
	
	public void OnChangeScale()
    {
        Vector3 newScale = processSliderValue(slider.SliderValue);
        float newScaleLength = newScale.magnitude;
       
        objectScale.transform.localScale = newScale;
        /*float newXPos = objectScale.position.x - newScaleLength;
        Vector3 newPosition = new Vector3(newXPos, objectScale.position.y, objectScale.position.z);
        objectScale.position = newPosition;*/
    }

    private Vector3 processSliderValue(float sliderValue)
    {
        float newScaleValue = sliderValue + SliderOffset;
        return new Vector3(newScaleValue, newScaleValue, newScaleValue);
    }
}
