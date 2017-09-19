using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleManipulationType : MonoBehaviour {


    private void Start()
    {
    }

    public void SetDefaultHandler()
    {
        OnRotate();
    }

    public void OnRotate()
    {
        ChangeManipulationType(ManipulationMode.ROTATION);
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
        ChangeManipulationType(ManipulationMode.MOVEMENT);
    }

    public void OnScale()
    {
        ChangeManipulationType(ManipulationMode.SCALING);
    }

}
