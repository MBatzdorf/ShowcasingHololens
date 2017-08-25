using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;

// Adapted from https://unity3d.com/de/learn/tutorials/topics/user-interface-ui/adding-buttons-script?playlist=17111
// ArrayOrder from http://answers.unity3d.com/questions/271910/c-sorting-a-list-of-gameobjects-alphabetically.html

public class ObjectListBehavior : MonoBehaviour {

	public Transform contentPanel;
	public GameObject buttonPrefab;
	public Button resetButton;

	private GameObject[] listItems;

	// Use this for initialization
	void Start () {

		if (contentPanel != null && buttonPrefab != null && resetButton != null)
		{
			// Add reset method to ResetButton
			resetButton.onClick.AddListener (HandleResetButtonClicked);

			// Get all InteractableObjects ordered alphabetically
			listItems = GameObject.FindGameObjectsWithTag ("InteractableObject").OrderBy(go => go.name).ToArray();

			FillListWithPrefabButtons ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Creates and adds a list item to the scroll view for each InteractableObject
	void FillListWithPrefabButtons()
	{
		foreach (GameObject item in listItems)
		{
			GameObject newButton = (GameObject) Instantiate (buttonPrefab, contentPanel);
			ObjectSpawnButton sb = newButton.GetComponent<ObjectSpawnButton> ();
			sb.LinkButtonWithObject (item);
		}
	}

	// Reload the current scene
	void HandleResetButtonClicked()
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}
}
