using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Скрипт, переключающий сцены, при соприкосновении игрока с объектом
/// </summary>
public class Finish : MonoBehaviour
{
    /// <summary>
    /// Индекс следующей сцены
    /// </summary>
    public int NextScene;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(NextScene);
        }
    }
}
