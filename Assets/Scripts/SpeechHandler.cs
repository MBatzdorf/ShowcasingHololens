using HoloToolkit.Unity.InputModule;
using UnityEngine;
using System;

public class SpeechHandler : MonoBehaviour{

    private ManipulationHandler manipulationHandler;
    private NavigationHandler navigationHandler;

    private void Awake()
    {
        manipulationHandler = GetComponent<ManipulationHandler>();
        navigationHandler = GetComponent<NavigationHandler>();
        ResetGestureHandler();
    }

    private void ResetGestureHandler()
    {
		OnActivateNavigation();
    }

    public void OnActivateNavigation()
    {
        Debug.Log("On activate navigation");
        manipulationHandler.IsActive = false;
        navigationHandler.IsActive = true;
    }

    public void OnActivateManipulation()
    {
        Debug.Log("On activate manipulation");
        manipulationHandler.IsActive = true;
        navigationHandler.IsActive = false;
    }
}
