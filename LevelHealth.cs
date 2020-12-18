using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[AddComponentMenu ("My Components/Enemy/Level health")]
public class LevelHealth : MonoBehaviour
{
    [HideInInspector]
    public int levelHealth = 100;

    [Header ("Level Health")]
    public Text myText;

    void Update()
    {
        myText.text = "" + levelHealth + "";

        if(levelHealth <= 0)
        {
            SceneManager.LoadScene(4);
        }
    }
}
