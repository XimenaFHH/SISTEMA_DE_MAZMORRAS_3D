using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectInteract : MonoBehaviour
{
   

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
           
            Destroy(gameObject);
        }

        
           
    }
}

