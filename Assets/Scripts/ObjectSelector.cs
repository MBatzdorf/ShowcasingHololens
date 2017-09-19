using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ObjectSelector : MonoBehaviour, IInputClickHandler {
    public void OnInputClicked(InputClickedEventData eventData)
    {
        /*if (ObjectStateManager.Instance.SelectedObject != gameObject)
        {*/
            ObjectStateManager.Instance.SelectedObject = gameObject;
        /*}
        else
        {
            ObjectStateManager.Instance.SelectedObject = null;
        }*/
    }
}
