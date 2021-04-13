using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Скрипт, определяющий поведение и управление игрока
/// </summary>
public class PlayerController : MonoBehaviour
{
    /// <summary>
    /// Объект камеры, для реализации движения в сторону, куда смотрит камера
    /// </summary>
    public GameObject Cam;

    /// <summary>
    /// rb игрока, для реализации передвижения
    /// </summary>
    public Rigidbody rb;

    /// <summary>
    /// Трансформ объекта, где будет находиться начало уровня
    /// </summary>
    public Transform StartLevel;

    /// <summary>
    /// Список чекпоинтов, для возвращения к последнему
    /// </summary>
    private List<Vector3> CheckPoints = new List<Vector3>(){ };

    /// <summary>
    /// Колличество жизней игрока
    /// </summary>
    public int Life = 3;

    /// <summary>
    /// Сила передвижения игрока
    /// </summary>
    public float force;

    /// <summary>
    /// Сила прыжка
    /// </summary>
    public float jumpForce;

    /// <summary>
    /// Кулдаун прыжка
    /// </summary>
    private float jumpTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        CheckPoints.Add(StartLevel.position);
        transform.position = StartLevel.position;
    }


    void FixedUpdate()
    {
        if (jumpTime > 0)
        {
            jumpTime -= Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(Cam.transform.forward * force);
        }

        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(-Cam.transform.forward * force);
        }

        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(-Cam.transform.right * force);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Cam.transform.right * force);
        }

        if (Input.GetKeyDown(KeyCode.Space) && jumpTime <= 0)
        {
            jumpTime = 1;
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Checkpoint"))
        {
            CheckPoints.Add(other.GetComponent<Transform>().position);
        }

        if (other.CompareTag("Damage"))
        {
            Hit();
        }

    }

    /// <summary>
    /// Метод, срабатывающий при получении урона
    /// </summary>
    public void Hit()
    {
        rb.velocity = Vector3.zero;
        Life--;
        if (Life > 0)
        {
            transform.position = CheckPoints.Last();
        }
        else
        {
            Death();
        }
    }

    /// <summary>
    /// Метод, срабатывающий при опускании жизней до 0
    /// </summary>
    public void Death()
    {
        Scene thisScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(thisScene.buildIndex);
    }
}
