using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// based on http://dotnetbyexample.blogspot.de/2017/01/manipulating-holograms-move-scale.html


public class SpatialManipulator : MonoBehaviour
{
    public float movementSpeed = 0.1f;
    public float rotationSensitivity = 6f;
    public float scalingSpeed = 0.2f;

    private Vector3 defaultPosition = new Vector3(0, 0.25f, 0);
    private readonly Vector3 minScale = new Vector3(0.5f, 0.5f, 0.5f);

    public ManipulationMode Mode { get; set; }

    public void Manipulate(Vector3 manipulationData, ManipulationDataType dataType)
    {
        switch (Mode)
        {
            case ManipulationMode.MOVEMENT:
                Move(manipulationData);
                break;
            case ManipulationMode.ROTATION:
                if (dataType == ManipulationDataType.NAVIGATION_DATA)
                {
                    Rotate(manipulationData);
                }
                break;
            case ManipulationMode.SCALING:
                Scale(manipulationData);
                break;
        }
    }

    public void ResetPosition()
    {
        this.transform.localPosition = new Vector3(0, 0.25f, 0);
        this.transform.localScale = new Vector3(.5f, .5f, .5f);
        this.transform.localEulerAngles = new Vector3(0, 0, 0);
    }

    private void Scale(Vector3 manipulationData)
    {
        if (transform.localScale.x > minScale.x)
        {
            transform.localScale *= 1.0f - (manipulationData.z * scalingSpeed);
        }
    }

    private void Rotate(Vector3 manipulationData)
    {
        float rotationFactorX = manipulationData.y * rotationSensitivity;
        float rotationFactorY = manipulationData.x * rotationSensitivity;
        this.transform.Rotate(new Vector3(rotationFactorX, -1 * rotationFactorY, 0));
    }

    private void Move(Vector3 manipulationData)
    {
        Vector3 directionVector = manipulationData * movementSpeed;
        transform.position += directionVector;
    }
}
