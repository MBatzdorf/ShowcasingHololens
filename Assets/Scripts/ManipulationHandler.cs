using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ManipulationHandler : MonoBehaviour, IManipulationHandler {
    public void OnManipulationCanceled(ManipulationEventData eventData)
    {
        throw new NotImplementedException();
    }

    public void OnManipulationCompleted(ManipulationEventData eventData)
    {
        throw new NotImplementedException();
    }

    public void OnManipulationStarted(ManipulationEventData eventData)
    {
        throw new NotImplementedException();
    }

    public void OnManipulationUpdated(ManipulationEventData eventData)
    {
        Vector3 inputData = eventData.CumulativeDelta;

    }

}
