using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitSound : MonoBehaviour
{
    public GameObject hitSound;
    private AudioSource collisionSound;

    // Start is called before the first frame update
    void Awake()
    {
        collisionSound = hitSound.GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        collisionSound.Play();
    }
}
