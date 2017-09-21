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

    public void OnMove()
    {
        ChangeManipulationType(ManipulationMode.MOVEMENT);
    }
        
    public void OnRotate()
    {
        ChangeManipulationType(ManipulationMode.ROTATION);
    }

    public void OnScale()
    {
        ChangeManipulationType(ManipulationMode.SCALING);
    }

    public void OnReset()
    {
        ChangeManipulationType(ManipulationMode.NONE);
    }

    private void ChangeManipulationType(ManipulationMode manipulationMode)
    {
        if (gameObject == ObjectStateManager.Instance.SelectedObject)
        {
            SpatialManipulator spatialManipulator = GetManipulator();
            if (spatialManipulator == null)
            {
                return;
            }
            if (spatialManipulator.Mode != manipulationMode)
            {
                if(manipulationMode == ManipulationMode.NONE)
                {
                    spatialManipulator.ResetPosition();
                    return;
                }
                spatialManipulator.Mode = manipulationMode;
                Debug.Log("NEW manipulation mode: " + spatialManipulator.Mode);

            }
        }
        else
        {
            Debug.Log("This object is currently not selected!");
        }
    }

    private SpatialManipulator GetManipulator()
    {
        //var lastSelectedObject = ObjectStateManager.Instance.SelectedObject;
        /*if (lastSelectedObject == null)
        {
            Debug.Log("No selected element found");
            return null;
        }*/
        //var manipulator = lastSelectedObject.GetComponent<SpatialManipulator>();
        SpatialManipulator manipulator = GetComponent<SpatialManipulator>();
        if (manipulator == null)
        {
            //manipulator = lastSelectedObject.GetComponentInChildren<SpatialManipulator>();
            manipulator = GetComponentInChildren<SpatialManipulator>();
        }

        if (manipulator == null)
        {
            Debug.Log("No manipulator component found");
        }
        return manipulator;
    }
}
