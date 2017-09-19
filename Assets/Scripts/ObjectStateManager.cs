using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;
using System;
using HoloToolkit.Unity;

// based on http://dotnetbyexample.blogspot.de/2017/01/manipulating-holograms-move-scale.html

public class ObjectStateManager : Singleton<ObjectStateManager>, IManipulationHandler, INavigationHandler {

    private GameObject mSelectedObject;

    public GameObject SelectedObject
    {
        get { return mSelectedObject; }
        set
        {
            if (mSelectedObject != value)
            {
                ResetDeselectedObject(mSelectedObject);
                mSelectedObject = value;
                SetDefaultManipulationType();
            }
        }

    }

    // Use this for initialization
    void Start()
    {
        InputManager.Instance.AddGlobalListener(gameObject);
    }

    private void SetDefaultManipulationType()
    {
        ToggleManipulationType toggleManipulationType = GetManipulationToggler(mSelectedObject);
        toggleManipulationType.SetDefaultHandler();
    }

    private ToggleManipulationType GetManipulationToggler(GameObject mSelectedObject)
    {
        return mSelectedObject.GetComponent<ToggleManipulationType>();
    }

    private void ResetDeselectedObject(GameObject previousObject)
    {
        var manipulator = GetManipulator(previousObject);
        if (manipulator != null)
        {
            manipulator.Mode = ManipulationMode.NONE;
        }
    }

    public void OnManipulationUpdated(ManipulationEventData eventData)
    {
        SpatialManipulator spatialManipulator = GetManipulator(SelectedObject);
        spatialManipulator.Manipulate(eventData.CumulativeDelta, ManipulationDataType.MANIPULATION_DATA);
    }

    private SpatialManipulator GetManipulator(GameObject selectedObject)
    {
        if(selectedObject == null) { return null; }
        SpatialManipulator spatialManipulator = selectedObject.GetComponent<SpatialManipulator>();
        return spatialManipulator;
    }
    
    public void OnNavigationUpdated(NavigationEventData eventData)
    {
        Debug.Log("IN NAVIGATION UPDATE!");
        SpatialManipulator spatialManipulator = GetManipulator(SelectedObject);
        spatialManipulator.Manipulate(eventData.CumulativeDelta, ManipulationDataType.NAVIGATION_DATA);
    }

    public void OnNavigationCanceled(NavigationEventData eventData)
    { }

    public void OnNavigationCompleted(NavigationEventData eventData)
    { }

    public void OnNavigationStarted(NavigationEventData eventData)
    { }

    public void OnManipulationCanceled(ManipulationEventData eventData)
    { }

    public void OnManipulationCompleted(ManipulationEventData eventData)
    { }

    public void OnManipulationStarted(ManipulationEventData eventData)
    { }
}
