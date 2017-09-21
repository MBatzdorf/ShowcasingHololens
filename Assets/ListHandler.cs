using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListHandler : MonoBehaviour {

    public GameObject tutorial;
    private const int TUTORIAL = 3;
    public enum MenuOptions
    {
        LEHRBUCH,
        TUTORIAL
    }
    private Dropdown dropdownMenu;
    // Use this for initialization
	void Start () {
        dropdownMenu = GetComponent<Dropdown>();
    }
	
    public void OnOptionChanged()
    {
        if(dropdownMenu.value == TUTORIAL)
        {
            tutorial.SetActive(true);
        }
    }

    public void OnSetDefaultMenuOption()
    {
        dropdownMenu.value = 0;
    }
}
