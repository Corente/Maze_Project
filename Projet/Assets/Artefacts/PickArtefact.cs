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
            //gameObject.GetComponent<ParticleSystem>().main.gravityModifier = 1f;
            while (i < 100)
            {
                Debug.Log(i);
                gameObject.transform.Translate(0, 0, 0.1f);
                i += 1;
            }
            Destroy(gameObject);
        }
    }
}
