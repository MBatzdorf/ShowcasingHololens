using UnityEngine;

// Taken and adapted from https://developer.microsoft.com/en-us/windows/mixed-reality/holograms_101e

public class GazeManager : MonoBehaviour {

	// Singleton instance of this class
	public static GazeManager Instance { get; private set; }

	// The hologram currently being gazed at
	public GameObject FocusedObject { get; private set; }

	// Use this for initialization
	void Start () {
		Instance = this;
	}
	
	// Update is called once per frame
	void Update () {

		GameObject oldFocusedObject = FocusedObject;
		
		// Do a raycast into the world based on the user's
		// head position and orientation.
		var headPosition = Camera.main.transform.position;
		var gazeDirection = Camera.main.transform.forward;

		RaycastHit hitInfo;
		if (Physics.Raycast(headPosition, gazeDirection, out hitInfo))
		{
			// If the raycast hit a hologram, use that as the focused object.
			FocusedObject = hitInfo.collider.gameObject;
		}
		else
		{
			// If the raycast did not hit a hologram, clear the focused object.
			FocusedObject = null;
		}

		if (FocusedObject != oldFocusedObject) {
			Debug.Log ("Gaze is now at object \"" + FocusedObject.name + "\"");
			// TODO: react on gaze
		}
	}
}
