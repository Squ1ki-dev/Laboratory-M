using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

[RequireComponent(typeof(PauseMenu))]
public class DisableFPSController : MonoBehaviour {

    public FirstPersonController firstPersonController;
    PauseMenu pauseMenu;

	void Start () {
        pauseMenu = GetComponent<PauseMenu>();
	}
	
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
