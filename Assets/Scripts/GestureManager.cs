using UnityEngine;
using UnityEngine.VR.WSA.Input;

// Taken and adapted from https://developer.microsoft.com/en-us/windows/mixed-reality/holograms_101e

public class GestureManager : MonoBehaviour {

	// Singleton instance of this class
	public static GestureManager Instance { get; private set; }

	private GestureRecognizer recognizer;

	// Use this for initialization
	void Start () {
		Instance = this;

		// Set up a GestureRecognizer to detect Select gestures.
		recognizer = new GestureRecognizer();
		recognizer.TappedEvent += (source, tapCount, ray) =>
		{
			Debug.Log ("TappedEvent detected");
			GameObject focusedObject = GazeManager.Instance.FocusedObject;
			// Send an OnSelect message to the focused object and its ancestors.
			if (focusedObject != null)
			{
				// TODO: implement appropriate action
				//focusedObject.SendMessageUpwards("OnSelect");
			}
		};

		// TODO: implement HoldStartedEvent
		recognizer.HoldStartedEvent += (source, headRay) => {
			Debug.Log ("HoldStartedEvent detected");
		};

		// TODO: implement HoldCompletedEvent
		recognizer.HoldCompletedEvent += (source, headRay) => {
			Debug.Log ("HoldCompletedEvent detected");
		};

		// TODO: implement HoldCanceledEvent
		recognizer.HoldCanceledEvent += (source, headRay) => {
			Debug.Log ("HoldCanceledEvent detected");
		};

		// TODO: Implement more gesture events

		recognizer.StartCapturingGestures();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
