using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceKeeper : MonoBehaviour {

    public GameObject baseObject;
    public GameObject satelliteObject;

    private float maxDistance;
    private Vector3 positionBaseObject;
    private Vector3 positionSatelliteObject;

	// Use this for initialization
	void Start () {
        UpdateObjectPositions();
        maxDistance = Vector3.Distance(positionBaseObject, positionSatelliteObject);
	}

    // Update is called once per frame
    void Update () {
        UpdateObjectPositions();
        KeepDistance();
	}

    private void UpdateObjectPositions()
    {
        positionBaseObject = baseObject.transform.position;
        positionSatelliteObject = satelliteObject.transform.position;
    }

    private void KeepDistance()
    {
        float currentDistance = CalculateCurrentDistance(positionBaseObject, positionSatelliteObject);
        // based on http://answers.unity3d.com/questions/292084/keeping-distance-between-two-gameobjects.html
        satelliteObject.transform.position = (positionSatelliteObject - positionBaseObject).normalized * maxDistance + positionBaseObject;
        return;
    }

    private float CalculateCurrentDistance(Vector3 positionObject1, Vector3 positionObject2)
    {
        return Vector3.Distance(positionObject1, positionObject2);
    }
}
