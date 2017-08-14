using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestureAction : MonoBehaviour {

    [Tooltip("Rotation max speed controls amount of rotation.")]
    public float RotationSensitivity = 10.0f;

    private Vector3 manipulationPreviousPosition;

    private float rotationFactorX;
    private float rotationFactorY;
    private float rotationFactorZ;

    void Update()
    {
        PerformRotation();
    }

    private void PerformRotation()
    {
        if (GestureManager.Instance.IsNavigating)
        {

            // This will help control the amount of rotation.
            rotationFactorX = GestureManager.Instance.NavigationPosition.y * RotationSensitivity;
            rotationFactorY = GestureManager.Instance.NavigationPosition.x * RotationSensitivity;
            //rotationFactorZ = GestureManager.Instance.NavigationPosition.x * RotationSensitivity;

            transform.Rotate(new Vector3(-1 * rotationFactorX, -1 * rotationFactorY, 0));
        }
    }    
}
