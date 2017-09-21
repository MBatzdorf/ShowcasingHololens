using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectSpawnButton : MonoBehaviour {

	public Text objectName;
	public Image objectIcon;
	public Transform spawnPosition;

	private Button spawnButton;
	private GameObject interactableObject;

	private GameObject interactableObjectChild;
	private Transform initialChildTransform;

	// Use this for initialization
	void Start () {
		spawnButton = gameObject.GetComponent<Button> ();
		if(spawnButton)
			spawnButton.onClick.AddListener (HandleClick);
	}


	// Associate a GameObject with this button
	public void LinkButtonWithObject(GameObject go)
	{
		if (go == null)
			return;
		objectName.text = go.name;
		interactableObject = go;

		foreach (Transform t in interactableObject.GetComponentsInChildren<Transform>()) {
			if (t.tag == "InteractableObjectChild") {
				interactableObjectChild = t.gameObject;
				initialChildTransform = t;
			}
		}
	}


	// Detaches the associated GameObject and places it at the predefined spawn position
	public void HandleClick()
	{
		if (interactableObject && spawnPosition) 
		{
			Vector3 tmpScale = interactableObject.transform.localScale;
			interactableObject.transform.SetParent (null);
			interactableObject.transform.position = spawnPosition.position;
			interactableObject.transform.localScale = tmpScale;
			interactableObjectChild.transform.localPosition = initialChildTransform.position;
			interactableObjectChild.transform.rotation = initialChildTransform.rotation;
			interactableObjectChild.transform.localScale = initialChildTransform.localScale;
			interactableObject.GetComponentInChildren<Renderer> ().enabled = true;
			interactableObject.GetComponentInChildren<Collider> ().enabled = true;
			interactableObject.GetComponent<AudioSource> ().Play ();
		}
	}
}
