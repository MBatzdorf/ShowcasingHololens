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

    public ManipulationMode Mode { get; set; }

    public void Manipulate(Vector3 manipulationData, ManipulationDataType dataType)
    {
        switch (Mode)
        {
            case ManipulationMode.MOVEMENT:
                Debug.Log("MMMOOOOVVVEEE");
                Move(manipulationData);
                break;
            case ManipulationMode.ROTATION:
                Debug.Log("RRRRROOOOOOOOOTTTTTTAAAAAAATTTTTTTEEEE 111111");
                if (dataType == ManipulationDataType.NAVIGATION_DATA)
                {
                    Debug.Log("RRRRROOOOOOOOOTTTTTTAAAAAAATTTTTTTEEEE 22222");
                    Rotate(manipulationData);
                }
                break;
            case ManipulationMode.SCALING:
                Debug.Log("SSSCCCAAAALLLEEE!");
                Scale(manipulationData);
                break;
        }
    }

    private void Scale(Vector3 manipulationData)
    {
        transform.localScale *= 1.0f - (manipulationData.z * scalingSpeed);
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
