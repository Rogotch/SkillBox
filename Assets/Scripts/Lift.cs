using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lift : MonoBehaviour
{
    public Rigidbody objRb;
    public Transform firstPosition;
    public Transform secondPosition;
    private Vector3 directionVector;
    private bool flag = false;
    private bool endFlag = true;
    public float speed = 1;
    public bool Up = true;
    public bool OneCirle = false;

    // Start is called before the first frame update
    void Start()
    {
        directionVector = transform.up;
        if (Up)
        {
            objRb.GetComponent<Transform>().position = firstPosition.position;
        }
        else
        {
            objRb.GetComponent<Transform>().position = secondPosition.position;
        }

        objRb.GetComponent<Rigidbody>().isKinematic = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (flag)
        {
            if (objRb.GetComponent<Transform>().position.y <= firstPosition.position.y)
            {
                directionVector = transform.up;
                if (Up == false && OneCirle)
                {
                    flag = false;
                    endFlag = false;
                }
            }

            if (objRb.GetComponent<Transform>().position.y >= secondPosition.position.y)
            {
                directionVector = -transform.up;
                if (Up && OneCirle)
                {
                    flag = false;
                    endFlag = false;
                }
            }

            objRb.MovePosition((objRb.GetComponent<Transform>().position + speed * directionVector * Time.fixedDeltaTime));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && endFlag)
        {
            flag = true;
        }
    }
}
