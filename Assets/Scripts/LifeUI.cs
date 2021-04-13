using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TextEditor = UnityEditor.UI.TextEditor;

/// <summary>
/// Скрипт, выводящий текущее количество жизней на экран
/// </summary>
public class LifeUI : MonoBehaviour
{
    public PlayerController Controller;

    public Text Editor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Editor.text = "Жизни: " + Controller.Life;
    }
}
