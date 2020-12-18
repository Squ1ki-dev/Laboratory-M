using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubText : MonoBehaviour {
	public string[] textSubtitle;

	[SerializeField]private Text subtext;
	[SerializeField]private AudioSource audioSource;
    	[SerializeField] private AudioClip dialogClip;

	[SerializeField] private float NextText;
	[SerializeField] private int endVoice;
	[SerializeField] private float timer;
	private int i;

	void Start () {
		
	}

	void FixedUpdate () 
	{
		subtext.text = textSubtitle[i];
		timer += 1 * Time.deltaTime;
		if (timer >= NextText) 
		{
			i += 1;
			timer = 0;
		}
	}

	void OnTriggerEnter(Collider col)
    {
        if (col.GetComponent<Collider>().tag == "Player")
        {
            audioSource.PlayOneShot(dialogClip);
        }
    }
}
