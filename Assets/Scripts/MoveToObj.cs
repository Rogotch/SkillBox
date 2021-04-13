using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

//Скрипт, реализующий движение за привязанным объектом, не учитывая параметры scale и rotate
public class MoveToObj : MonoBehaviour
{
    public Transform objToFollow;

    private Vector3 deltaPos;

    void Start()
    {
        deltaPos = transform.position - objToFollow.position;
    }

    void Update()
    {
        transform.position = objToFollow.position + deltaPos;
    }
}
