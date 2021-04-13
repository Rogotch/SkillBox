using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TramplinSound : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GetComponent<AudioSource>().Play();

        }
    }
}
