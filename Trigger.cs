using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Trigger : MonoBehaviour
{
    [SerializeField]
    private int sceneIndex;

    [SerializeField] private GameObject Text;
    private GameObject player;

    void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            Text.SetActive (true);
            if(Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene(sceneIndex);
            }
        }
    }
    
    void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player") 
        {
			Text.SetActive (false);
		}
	}
}
