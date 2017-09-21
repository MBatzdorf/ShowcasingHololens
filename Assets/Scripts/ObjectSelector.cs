using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// based on http://dotnetbyexample.blogspot.de/2017/01/manipulating-holograms-move-scale.html

public class ObjectSelector : MonoBehaviour, IInputClickHandler {
    public void OnInputClicked(InputClickedEventData eventData)
    {
        if (!eventData.used)
        {
            bool isGazingUI = IsGazingUI();
            if (!isGazingUI)
            {
                if (ObjectStateManager.Instance.SelectedObject != GazeManager.Instance.HitObject)
                {
                    ObjectStateManager.Instance.SelectedObject = GazeManager.Instance.HitObject;
                }
                else
                {
                    ObjectStateManager.Instance.SelectedObject = null;
                }
            }
            else
            {
                return;
            }
            eventData.Use();
        }
    }

    private bool IsGazingUI()
    {
        if (GazeManager.Instance.IsGazingAtObject)
        {
            if (GazeManager.Instance.HitObject.layer == LayerMask.NameToLayer("UI"))
            {
                return true;
            }
        }
        return false;
    }
}
