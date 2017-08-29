using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectScaler : MonoBehaviour {

    public Slider slider;

    private Transform objectScale;

    // Use this for initialization
	void Start () {
        objectScale = GetComponent<Transform>();
	}
	
	public void OnChangeScale()
    {
        objectScale.transform.localScale = new Vector3(slider.value, slider.value, slider.value);
    }
}
