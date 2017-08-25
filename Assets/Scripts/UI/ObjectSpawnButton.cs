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
			interactableObject.GetComponent<Renderer> ().enabled = true;
			interactableObject.GetComponent<Collider> ().enabled = true;

			Debug.Log ("Button " + objectName.text + " clicked.");
		}
	}
}
