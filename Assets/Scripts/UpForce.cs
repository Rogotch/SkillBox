using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Скрипт, реализующий медленное поднятие игрока, находящегося внутри объекта
/// </summary>
public class UpForce : MonoBehaviour
{
    /// <summary>
    /// Сила поднятия
    /// </summary>
    public float force;
    private void OnTriggerStay(Collider other)
    {
        Rigidbody playerRb;
        if (other.CompareTag("Player"))
        {
            playerRb = other.GetComponent<Rigidbody>();
            //playerRb.AddForce(Vector3.up * force, ForceMode.VelocityChange);
            playerRb.isKinematic = true;
            playerRb.MovePosition(playerRb.GetComponent<Transform>().position + transform.up * Time.fixedDeltaTime);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Rigidbody playerRb;
        if (other.CompareTag("Player"))
        {
            playerRb = other.GetComponent<Rigidbody>();
            playerRb.isKinematic = false;

        }
    }
}
