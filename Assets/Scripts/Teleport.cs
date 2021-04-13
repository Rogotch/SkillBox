using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Скрипт, реализующий функционал телепорта
/// </summary>
public class Teleport : MonoBehaviour
{
    /// <summary>
    /// Положение "выхода из телепорта"
    /// </summary>
    public Transform exit;
    
    /// <summary>
    /// Переменная, определяющая, для кого предназначен телепорт - для игрока или объектов
    /// </summary>
    public bool PlayerOrObject = true;
    private void OnTriggerEnter(Collider other)
    {
        string tag;
        if (PlayerOrObject)
        {
            tag = "Player";
        }
        else
        {
            tag = "Object";
        }

        TeleportObj(other, tag);
    }

    /// <summary>
    /// Изменение координат объекта или игрока на координаты выхода
    /// </summary>
    /// <param name="other">Игрок или объект</param>
    /// <param name="tag">Тег, кому предназначается этот телепорт</param>
    public void TeleportObj(Collider other, string tag)
    {
        if (other.CompareTag(tag))
        {
            exit.GetComponent<AudioSource>().Play();
            other.GetComponent<Transform>().position = exit.position;
        }
    }
}
