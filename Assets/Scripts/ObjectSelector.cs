using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ObjectSelector : MonoBehaviour, IInputClickHandler {
    public void OnInputClicked(InputClickedEventData eventData)
    {
        Debug.Log("Selected Object " + gameObject.name);
        ObjectStateManager.Instance.SelectedObject = gameObject;
    }
}
