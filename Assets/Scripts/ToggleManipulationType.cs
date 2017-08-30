using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleManipulationType : MonoBehaviour {

    public Text buttonText;

    private ManipulationHandler manipulationHandler;
    private NavigationHandler navigationHandler;

    private bool isNavigationActive = false;

    private void Awake()
    {
        manipulationHandler = GetComponent<ManipulationHandler>();
        navigationHandler = GetComponent<NavigationHandler>();
        SetDefaultHandler();
    }

    private void SetDefaultHandler()
    {
        OnActivateNavigationHandler();
    }

    public void OnActivateNavigationHandler()
    {
        Debug.Log("On activate navigation in toggle script");
        isNavigationActive = true;
        manipulationHandler.IsActive = false;
        navigationHandler.IsActive = true;
    }

    public void OnActivateManipulationHandler()
    {
        Debug.Log("On activate manipulation in toggle script");
        isNavigationActive = false;
        manipulationHandler.IsActive = true;
        navigationHandler.IsActive = false;
    }

    public void OnToggle()
    {
        if (isNavigationActive)
        {
            buttonText.text = "Activate Navigation";
            OnActivateManipulationHandler();
        }
        else
        {
            buttonText.text = "Activate Manipulation";
            OnActivateNavigationHandler();
        }
    }
}
