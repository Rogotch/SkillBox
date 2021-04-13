using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Скрипт, реализующий вращение камеры путём вращения родительского объекта камеры
/// </summary>
public class CameraRotate : MonoBehaviour
{
    public GameObject Cam;
    private float MyAngle = 0F;
    private Vector3 MousePos;
    public float CameraRotateSpeed = 1;

    void Update()
    {
        MousePos = Input.mousePosition;
        if (Input.GetMouseButton(1))
        {
            MyAngle = 0;
            MyAngle = ((MousePos.x - (Screen.width / 2)) / Screen.width) * Time.deltaTime * CameraRotateSpeed;
            Cam.transform.Rotate( Cam.transform.up, MyAngle);
        }
    }
}
