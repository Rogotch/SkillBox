using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CheckpointSound : MonoBehaviour
{
    public GameObject checkpointSound;
    private AudioSource checkPSound;
    private List<Transform> checkpointsList;

    // Start is called before the first frame update
    void Awake()
    {
        checkPSound = checkpointSound.GetComponent<AudioSource>();
        checkpointsList = new List<Transform>();
    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Checkpoint") && (checkpointsList.Count == 0 || other.GetComponent<Transform>() != checkpointsList.Last()))
        {
            checkpointsList.Add(other.GetComponent<Transform>());
            checkPSound.Play();
        }
    }
}
