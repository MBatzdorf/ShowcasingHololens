using HoloToolkit.Unity.InputModule;
using UnityEngine;
using System;

public class SpeechHandler : MonoBehaviour{

    /*private ManipulationHandler manipulationHandler;
    private NavigationHandler navigationHandler;*/
    private ToggleManipulationType toggleManipulationType;

    private void Awake()
    {
        /*manipulationHandler = GetComponent<ManipulationHandler>();
        navigationHandler = GetComponent<NavigationHandler>();*/
        toggleManipulationType = GetComponent<ToggleManipulationType>();
        //ResetGestureHandler();
    }

    private void ResetGestureHandler()
    {
		OnActivateNavigation();
    }

    public void OnActivateNavigation()
    {
        Debug.Log("On activate navigation");
        toggleManipulationType.OnActivateNavigationHandler();
        /*manipulationHandler.IsActive = false;
        navigationHandler.IsActive = true;*/
    }

    public void OnActivateManipulation()
    {
        Debug.Log("On activate manipulation");
        toggleManipulationType.OnActivateManipulationHandler();
        /*manipulationHandler.IsActive = true;
        navigationHandler.IsActive = false;*/
    }
}
