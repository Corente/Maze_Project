using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using JetBrains.Annotations;
using UnityEngine;

public class PickArtefact : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        int i = 0;
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
