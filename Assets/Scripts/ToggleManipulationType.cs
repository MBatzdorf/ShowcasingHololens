using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleManipulationType : MonoBehaviour {

    //public Text buttonText;

    //private bool isNavigationActive = false;

    private void Start()
    {
    }

    public void SetDefaultHandler()
    {
        OnRotate();
    }

    public void OnRotate()
    {
        Debug.Log("On activate navigation in toggle script");
        ChangeManipulationType(ManipulationMode.ROTATION);
        //isNavigationActive = true;
    }

    private void ChangeManipulationType(ManipulationMode manipulationMode)
    {
        SpatialManipulator spatialManipulator = GetManipulator();
        if (spatialManipulator == null)
        {
            return;
        }
        if (spatialManipulator.Mode != manipulationMode)
        {
            spatialManipulator.Mode = manipulationMode;
            Debug.Log("NEW manipulation mode: " + spatialManipulator.Mode);

        }
    }

    private SpatialManipulator GetManipulator()
    {
        var lastSelectedObject = ObjectStateManager.Instance.SelectedObject;
        if (lastSelectedObject == null)
        {
            Debug.Log("No selected element found");
            return null;
        }
        var manipulator = lastSelectedObject.GetComponent<SpatialManipulator>();
        if (manipulator == null)
        {
            manipulator = lastSelectedObject.GetComponentInChildren<SpatialManipulator>();
        }

        if (manipulator == null)
        {
            Debug.Log("No manipulator component found");
        }
        return manipulator;
    }

    public void OnMove()
    {
        Debug.Log("On activate manipulation in toggle script");
        ChangeManipulationType(ManipulationMode.MOVEMENT);
        //isNavigationActive = false;
    }

    public void OnScale()
    {
        ChangeManipulationType(ManipulationMode.SCALING);
    }

    /*public void OnToggle()
    {
        if (isNavigationActive)
        {
            buttonText.text = "Activate Rotation";
            OnMove();
        }
        else
        {
            buttonText.text = "Activate Movement";
            OnRotate();
        }
    }*/
}
