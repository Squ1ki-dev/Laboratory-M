using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu ("My Components/Enemy/Damage")]
public class Damage : MonoBehaviour
{
    [Header("Damage")]
    public int damage = 10;

    void OnTriggerEnter(Collider myCollider)
    {
        if (myCollider.tag == "Player")
        {
            myCollider.GetComponent <LevelHealth> ().levelHealth -= (damage);
        }
    }
}