using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionTypeButtonBehavior : MonoBehaviour {

	public Button button;
	public ToggleManipulationType manipulationToggler;
	public SpatialManipulator manipulator;
	public Image manipulateButtonImage;
	public Sprite rotateImage;
	public Sprite scaleImage;
	public Sprite moveImage;

	private enum States {rotate, move, scale, numberOfTypes};
	private States currentState;
	private ManipulationMode lastMode;


	// Use this for initialization
	void Start () {
		button.onClick.AddListener (OnButtonClicked);
		currentState = States.rotate;
	}

	void Update()
	{
		Debug.Log ("Current Mode: " + manipulator.Mode);
		if (manipulator.Mode != lastMode) {
			switch (manipulator.Mode) {
			case ManipulationMode.MOVEMENT:
				manipulateButtonImage.sprite = moveImage;
				break;
			case ManipulationMode.ROTATION:
				manipulateButtonImage.sprite = rotateImage;
				break;
			case ManipulationMode.SCALING:
				manipulateButtonImage.sprite = scaleImage;
				break;
			}
		}

		lastMode = manipulator.Mode;
	}

	void OnButtonClicked()
	{
		Debug.Log ("Button clicked!");
		currentState += 1;
		switch (currentState) {
		case States.move:
			Debug.Log ("Toggled Move");
			manipulationToggler.OnMove ();
			break;
		case States.scale:
			Debug.Log ("Toggled Scale");
			manipulationToggler.OnScale ();
			break;
		case States.numberOfTypes:
			currentState = 0;
			Debug.Log ("Toggled Rotate");
			manipulationToggler.OnRotate ();
			break;
		}
	}
}
