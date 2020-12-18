using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

[RequireComponent(typeof(PauseMenu))]
public class DisableFPSController : MonoBehaviour {

    public FirstPersonController firstPersonController;
    PauseMenu pauseMenu;
	// Use this for initialization
	void Start () {
        pauseMenu = GetComponent<PauseMenu>();
	}
	
	// Update is called once per frame
	void Update () {
        if (pauseMenu.isPaused)
        {
            firstPersonController.enabled = false;
        }
        else
        {
            firstPersonController.enabled = true;
        }
	}
}
