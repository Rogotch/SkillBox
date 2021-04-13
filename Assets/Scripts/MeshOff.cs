using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

/// <summary>
/// Скрипт,"удаляющий" объект при соприкосновении с ним игрока
/// </summary>
public class MeshOff : MonoBehaviour
{
    public GameObject deadSound;
    public MeshRenderer mesh; //Меш объекта, который надо отключить
    public Collider objCollider; //Коллайдер объекта, который надо отключить
    private Collider otherCollider; //Переменная, хранящая в себе коллайдер объекта, спровоцировавшего триггер

    /// <summary>
    /// Время, за которое должна исчезнуть платформа
    /// </summary>
    public float timeOff; 

    /// <summary>
    /// Переменная, определяющая, какой триггер будет задействован
    /// </summary>
    public bool EnterOrExit;

    private bool Run = false;
    private void OnTriggerEnter(Collider other)
    {
        otherCollider = other;
        if (EnterOrExit)
        {
            Run = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        otherCollider = other;
        if (EnterOrExit == false)
        {
            Run = true;
        }
    }

    private void Update()
    {
        if (Run)
        {
            if (timeOff > 0)
            {
                timeOff -= Time.deltaTime;
            }
            else
            {
                Off(otherCollider);
            }

        }
    }

    /// <summary>
    /// Метод, отключающий коллайдер и меш объекта
    /// </summary>
    /// <param name="other">соллайдер, вызвавший срабатывание триггера</param>
    private void Off(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            deadSound.GetComponent<AudioSource>().Play();
            mesh.enabled = false;
            objCollider.enabled = false;
            Run = false;
        }
    }
}
