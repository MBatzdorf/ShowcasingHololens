using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionTypeButtonBehavior : MonoBehaviour {

	public Button button;
	public ToggleManipulationType manipulationToggler;
	public Image manipulateButtonImage;
	public Sprite rotateImage;
	public Sprite scaleImage;
	public Sprite moveImage;

	private enum States {rotate, move, scale, numberOfTypes};
	private States currentState;


	// Use this for initialization
	void Start () {
		button.onClick.AddListener (OnButtonClicked);
		currentState = States.rotate;
	}

	void OnButtonClicked()
	{
		currentState += 1;
		switch (currentState) {
		case States.move:
			manipulateButtonImage.sprite = moveImage;
			manipulationToggler.OnMove ();
			break;
		case States.scale:
			manipulateButtonImage.sprite = scaleImage;
			manipulationToggler.OnScale ();
			break;
		case States.numberOfTypes:
			currentState = 0;
			manipulateButtonImage.sprite = rotateImage;
			manipulationToggler.OnRotate ();
			break;
		}
	}
}
