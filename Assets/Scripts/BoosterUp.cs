using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Трамплин, подбрасывающий или толкающий игрока в нужном направлении
/// </summary>
public class BoosterUp : MonoBehaviour
{
    public float force;
    private void OnTriggerEnter(Collider other)
    {
        Rigidbody playerRb;
        if (other.CompareTag("Player"))
        {
            playerRb = other.GetComponent<Rigidbody>();
            playerRb.AddForce(transform.up * force, ForceMode.Impulse);

        }
    }
}
